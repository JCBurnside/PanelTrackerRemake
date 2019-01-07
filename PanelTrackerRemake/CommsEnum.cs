// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Indicate which comms tab is selected.
    /// </summary>
    public enum CommsEnum
    {
        /// <summary>
        /// Self explainatory.
        /// </summary>
        Chat,

        /// <summary>
        /// Refered to as inbox in game.
        /// </summary>
        DMs,

        /// <summary>
        /// Self explainatory.
        /// </summary>
        Social,

        /// <summary>
        /// Self explainatory.
        /// </summary>
        History,

        /// <summary>
        /// The new squadron tab in game.
        /// </summary>
        Squadron,

        /// <summary>
        /// Self explainatory.
        /// </summary>
        Settings
    }
}