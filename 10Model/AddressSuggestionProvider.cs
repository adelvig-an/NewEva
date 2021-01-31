using AutoCompleteTextBox.Editors;
using System.Collections;

namespace NewEva.Model
{
    public class AddressSuggestionProvider : ISuggestionProvider
    {
        public IEnumerable GetSuggestions(string filter)
        {
            var isCorrect = DadataService.GetSuggestions(filter, out Address[] address);
            if (isCorrect != false)
            {
                foreach (var adr in address)
                {
                    yield return adr;
                }
            }
        }
    }
}
