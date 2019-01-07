// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class EDPTConts
    {
        /// <summary>
        /// Gets the journal SessionState key <see cref="string"/>.
        /// </summary>
        public static string Journal => nameof(Journal);

        /// <summary>
        /// Gets the current panel sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentPanel => nameof(CurrentPanel);

        /// <summary>
        /// Gets the current comm tab sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentCommTab => nameof(CurrentCommTab);

        /// <summary>
        /// Gets the current target tab sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentTargetTab => nameof(CurrentTargetTab);

        /// <summary>
        /// Gets the current system tab sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentSystemTab => nameof(CurrentSystemTab);

        /// <summary>
        /// Gets the current srv roles tab sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentSrvRoleTab => nameof(CurrentSrvRoleTab);

        /// <summary>
        /// Gets the current ship roles tab sessionState key <see cref="string"/>.
        /// </summary>
        public static string CurrentShipRoleTab => nameof(CurrentShipRoleTab);

        /// <summary>
        /// Gets the string for the comms command.
        /// </summary>
        public static string CommsCommand => "((EDPT:comms))";

        /// <summary>
        /// Gets the string for the conatcts command.
        /// </summary>
        public static string ContactsCommand => "((EDPT:contacts))";

        /// <summary>
        /// Gets the string for the roles command.
        /// </summary>
        public static string RolesCommand => "((EDPT:roles))";

        /// <summary>
        /// Gets the string for the systems command.
        /// </summary>
        public static string SystemsCommand => "((EDPT:systems))";

        /// <summary>
        /// Gets the string for the next tab command.
        /// </summary>
        public static string NextTabCommand => "((EDPT:next tab))";

        /// <summary>
        /// Gets the string for the prev tab command.
        /// </summary>
        public static string PrevTabCommand => "((EDPT:prev tab))";

        /// <summary>
        /// Gets the string for the up command.
        /// </summary>
        public static string UpCommand => "((EDPT:up))";

        /// <summary>
        /// Gets the string for the right command.
        /// </summary>
        public static string RightCommand => "((EDPT:right))";

        /// <summary>
        /// Gets the string for the down command.
        /// </summary>
        public static string DownCommand => "((EDPT:down))";

        /// <summary>
        /// Gets the string for the left command.
        /// </summary>
        public static string LeftCommand => "((EDPT:left))";

        /// <summary>
        /// Gets the string for the accept command.
        /// </summary>
        public static string AcceptCommand => "((EDPT:accept))";

        /// <summary>
        /// Gets the string for the back command.
        /// </summary>
        public static string BackCommand => "((EDPT:back))";
    }
}