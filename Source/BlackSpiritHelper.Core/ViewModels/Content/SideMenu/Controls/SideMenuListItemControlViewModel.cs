﻿using System.Threading.Tasks;
using System.Windows.Input;

namespace BlackSpiritHelper.Core
{
    public class SideMenuListItemControlViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Title of the menu item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Enum <see cref="ApplicationPage"/>.
        /// </summary>
        public ApplicationPage PageEnum { get; set; }

        /// <summary>
        /// DataContent model of current content section.
        /// </summary>
        public ADataContentBaseViewModel DataContent { get; set; } = null;

        #endregion

        #region Command Flags

        private bool mOpenPageCommandFlag { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to open a new page.
        /// </summary>
        public ICommand OpenPageCommand { get; set; }

        #endregion

        #region Constructor

        public SideMenuListItemControlViewModel()
        {
            // Create commands.
            CreateCommands();
        }

        #endregion

        /// <summary>
        /// Create commands.
        /// </summary>
        private void CreateCommands()
        {
            OpenPageCommand = new RelayCommand(async () => await OpenPageAsync());
        }

        /// <summary>
        /// Command helper, open page async.
        /// </summary>
        /// <returns></returns>
        private async Task OpenPageAsync()
        {
            await RunCommandAsync(() => mOpenPageCommandFlag, async () =>
            {
                IoC.Application.GoToPage(PageEnum);
                await Task.Delay(1);
            });
        }
    }
}
