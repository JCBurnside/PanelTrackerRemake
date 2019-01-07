// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    /// <summary>
    /// Indicates the current tab the targets (left) panel is on.
    /// </summary>
    public enum TargetPanelEnum
    {
        /// <summary>
        /// Indicates the navigation tab is selected.
        /// </summary>
        Navigation,

        /// <summary>
        /// Indicates the transactions tab is selected.
        /// </summary>
        Transactions,

        /// <summary>
        /// Indicates the contacts tab is selected.
        /// </summary>
        Contacts,

        /// <summary>
        /// This is the weird one.  Indicates the target tab is selected (though it may be disabled depending on context).
        /// </summary>
        Target
    }
}