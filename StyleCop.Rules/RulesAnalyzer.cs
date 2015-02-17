using StyleCop.CSharp;

namespace StyleCop.Rules
{
    [SourceAnalyzer(typeof (CsParser))]
    public class RulesAnalyzer : SourceAnalyzer
    {
        private int _numberOfClasses;

        public override void AnalyzeDocument(CodeDocument currentCodeDocument)
        {
            var codeDocument = (CsDocument) currentCodeDocument;

            if (codeDocument.RootElement != null && !codeDocument.RootElement.Generated)
            {
                _numberOfClasses = 0;
                codeDocument.WalkDocument(CheckClasses, null, null);
            }
        }

        private bool CheckClasses(CsElement element, CsElement parentElement, object context)
        {
            if (element.ElementType == ElementType.Class)
            {
                _numberOfClasses++;
            }

            if (_numberOfClasses > 1)
            {
                AddViolation(parentElement, "OneClassPerFile", "OnlyOneClassPerFileAllowed");
            }

            return true;
        }
    }
}