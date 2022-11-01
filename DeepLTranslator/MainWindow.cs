using DeepL;
using System.Text;

namespace DeepLTranslator
{
    public partial class MainWindow : Form
    {
        private string _authKey = "590d8756-d0f3-7b45-868f-fc135ab30508:fx";
        private string _document;
        private string _textToTranslate;
        private string _translatedText;
        private string _locatonionFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            _locatonionFilePath = openFileDialog.FileName;

            if (!string.IsNullOrEmpty(_locatonionFilePath))
            {
                try
                {
                    _document = File.ReadAllText(_locatonionFilePath);
                }
                catch (Exception exc)
                {
                    txt_BeforeTranslate.Text = "The file is not a text document. Exception message: " + exc.Message;

                }

                _textToTranslate = PrepareDocumentForTranslation(_document);
                txt_BeforeTranslate.Text = _document;
            }
        }

        private async void btn_Translate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_textToTranslate))
            {
                var charactersToTranslate = _textToTranslate.ToArray().Length;
                _translatedText = await Task.Run(() => TranslateText(_textToTranslate));

                var result = RestoreToInputForm(_translatedText, _document);
                txt_AfterTranslate.Text = result;
            }
            else
                txt_AfterTranslate.Text = "Error";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var fileNumber = int.Parse(_locatonionFilePath.Split('\\')[3].Substring(0,3)).ToString();
            saveFileDialog.FileName = fileNumber + "_pl";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.ShowDialog();

            string path = saveFileDialog.FileName;

            if (!string.IsNullOrEmpty(path))
            {
                var textToSave = txt_AfterTranslate.Text;

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (TextWriter tw = new StreamWriter(path, true, Encoding.GetEncoding(1252)))
                {
                    tw.WriteLine(textToSave);
                }
            }          
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