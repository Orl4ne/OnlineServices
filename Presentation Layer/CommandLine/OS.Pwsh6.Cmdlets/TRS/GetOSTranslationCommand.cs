using OS.Common.Enumerations;
using OS.Common.SecurityServices.TransfertObjects;
using OS.Common.TranslationServices;
using System;
using System.Management.Automation;
using TranslationServices.BusinessLayer.UseCases;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;

//DOC https://github.com/PowerShell/PowerShell/blob/master/src/Microsoft.PowerShell.Commands.Management/commands/management/Computer.cs
namespace OS.Pwsh6.Cmdlets.TRS
{
    [Cmdlet(VerbsCommon.Get, "OSTranslation")]
    public class GetOSTranslationCommand : PSCmdlet, IDisposable
    {
        private readonly ITRSInternalServicesRole trs;
        private readonly ServiceAuthorization srvAuthorization;

        public GetOSTranslationCommand()
        {
            //trs = new TRSInternalServicesRole( /**/, new AzureCognitiveAgent(/**/,/**/ ));
            //srvAuthorization = GetSettingsFromConfig();
        }

        private ServiceAuthorization GetSettingsFromConfig()
        {
            throw new NotImplementedException();
        }

        #region Parameters

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PhraseTotranslate { get; set; }

        /// <summary>
        /// Emit the output.
        /// </summary>
        // [Alias("Restart")]
        [Parameter]
        public SwitchParameter PassThru { get; set; }


        //[Parameter]
        //[ValidateNotNullOrEmpty]
        //[Credential]
        //public PSCredential DomainCredential { get; set; }

        [Parameter]
        [ValidateSet(
            "English",
            "French",
            "Dutch")]
        public string OriginalLanguage { get; set; } = "English";

        #endregion Parameters

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        protected override void ProcessRecord()
        {
            var translation = trs.GetTranslations(srvAuthorization, GetTuple(OriginalLanguage, PhraseTotranslate));
            if (!PassThru.IsPresent)
            {
                Console.WriteLine($"English: {translation.English}");
                Console.WriteLine($"French: {translation.French}");
                Console.WriteLine($"Dutch: {translation.Dutch}");
            }
            else
            {
                //Pass info to pipe...
                WriteObject(translation);
            }

            base.ProcessRecord();
        }

        private Tuple<Language, string> GetTuple(string originalLanguage, string phrase)
        {
            Language lng;

            switch (originalLanguage)
            {
                case "English":
                    lng = Language.English;
                    break;
                case "French":
                    lng = Language.French;
                    break;
                case "Dutch":
                    lng = Language.Dutch;
                    break;
                default:
                    lng = Language.English;
                    break;
            }

            return new Tuple<Language, string>(lng, phrase);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            Dispose();
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            Dispose();
        }

        #region "IDisposable Members"

        /// <summary>
        /// Dispose Method.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            // Use SuppressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose Method.
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_timer != null)
                //{
                //    _timer.Dispose();
                //}

                //_waitHandler.Dispose();
                //_cancel.Dispose();
                //if (_powershell != null)
                //{
                //    _powershell.Dispose();
                //}
            }
        }

        #endregion "IDisposable Members"
    }
}
