using DeepL;

namespace DeepLTranslator
{
    public partial class MainWindow : Form
    {
        private string _authKey = "";
        private string _document;
        private string _textToTranslate;
        private string _translatedText; 

        public MainWindow()
        {
            InitializeComponent();
        }                                             

        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            var fileName = openFileDialog.FileName;
            _document = File.ReadAllText(fileName);

            _textToTranslate = PrepareDocumentForTranslation(_document);
            txt_BeforeTranslate.Text = _document;
        }

        private async void btn_Translate_Click(object sender, EventArgs e)
        {
            var charactersToTranslate = _textToTranslate.ToArray().Length;

            if (!string.IsNullOrEmpty(_textToTranslate))
                _translatedText = await Task.Run(() => TranslateText(_textToTranslate));
            else
                txt_AfterTranslate.Text = "Error";       
            
            var result = RestoreToInputForm(_translatedText, _document);
            txt_AfterTranslate.Text = result;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            string path = saveFileDialog.FileName;
            var textToSave = txt_AfterTranslate.Text;
            File.WriteAllText(path, textToSave);
        }

        private string PrepareDocumentForTranslation(string document)
        {
            var tabOfBlocks = document.Split("\r\n\r\n");
            var result = "";

            foreach (var singleBlock in tabOfBlocks)
            {
                var splitSingleBlock = singleBlock.Split("\r\n");

                if (splitSingleBlock.Length > 2)
                    result += splitSingleBlock[2] + Environment.NewLine;
            }

            return result;      
        }

        private async Task<string> TranslateText(string text)
        {
            var translator = new Translator(_authKey);

            var translatedText = await translator.TranslateTextAsync(
                  text,
                  LanguageCode.English,
                  LanguageCode.Polish);

            return translatedText.Text;
        }

        private string RestoreToInputForm(string translatedText, string inputText)
        {
            var tabOfBlocks = inputText.Split("\r\n\r\n");
            var key = translatedText.Split("\r\n");
            var keyIndex = 0;

            var result = "";

            foreach (var singleBlock in tabOfBlocks)
            {
                var splitSingleBlock = singleBlock.Split("\r\n");

                for (int i = 0; i < splitSingleBlock.Length; i++)
                {
                    if (i == splitSingleBlock.Length - 1 && key.Length > keyIndex)
                    {
                        result += key[keyIndex] + Environment.NewLine;
                        keyIndex++;
                    }
                    else
                        result += splitSingleBlock[i] + Environment.NewLine;
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}