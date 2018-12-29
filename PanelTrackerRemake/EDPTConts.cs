// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class EDPTConts
    {
        /// <summary>
        /// Gets the journal SessionState key <see cref="string"/>.
        /// </summary>
        internal static string Journal => nameof(Journal);

        /// <summary>
        /// Gets the current panel sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentPanel => nameof(CurrentPanel);

        /// <summary>
        /// Gets the current comm tab sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentCommTab => nameof(CurrentCommTab);

        /// <summary>
        /// Gets the current target tab sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentTargetTab => nameof(CurrentTargetTab);

        /// <summary>
        /// Gets the current system tab sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentSystemTab => nameof(CurrentSystemTab);

        /// <summary>
        /// Gets the current srv roles tab sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentSrvRoleTab => nameof(CurrentSrvRoleTab);

        /// <summary>
        /// Gets the current ship roles tab sessionState key <see cref="string"/>.
        /// </summary>
        internal static string CurrentShipRoleTab => nameof(CurrentShipRoleTab);
    }
}