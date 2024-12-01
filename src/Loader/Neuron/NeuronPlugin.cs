#if NR
using Neuron.Core;
using Neuron.Core.Plugins;
using UnityExplorer.Config;

namespace UnityExplorer.Loader.Neuron
{
    [Plugin(
        Name = ExplorerCore.NAME,
        Description = "An runtime explorer for unity",
        Version = ExplorerCore.VERSION,
        Author = ExplorerCore.AUTHOR,
        Repository = "https://github.com/yukieiji/UnityExplorer/",
        Website = "https://github.com/yukieiji/UnityExplorer/"
    )]
    public class NeuronPlugin : Plugin, IExplorerLoader
    {
        private readonly NeuronBase _neuronBase;
        private readonly StandaloneConfigHandler _configHandler;

        public string ExplorerFolderName => ExplorerCore.DEFAULT_EXPLORER_FOLDER_NAME;
        public string ExplorerFolderDestination => _neuronBase.Platform.Configuration.BaseDirectory;
        public string UnhollowedModulesFolder => _neuronBase.PrepareRelativeDirectory("Managed");

        public ConfigHandler ConfigHandler => _configHandler;

        public Action<object> OnLogMessage => Logger.Info;

        public Action<object> OnLogWarning => Logger.Warn;

        public Action<object> OnLogError => Logger.Error;

        public NeuronPlugin()
        {
            _neuronBase = Globals.Get<NeuronBase>();
            _configHandler = new StandaloneConfigHandler();
        }

        public override void Enable()
        {
            ExplorerCore.Init(this);
        }
    }
}
#endif