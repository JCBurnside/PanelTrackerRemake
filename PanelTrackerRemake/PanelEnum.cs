// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    /// <summary>
    /// Enumeration to indicate in
    /// </summary>
    public enum PanelEnum
    {
        /// <summary>
        /// Indicates not currently looking at a panel.
        /// </summary>
        None,

        /// <summary>
        /// Indicates looking at the targets (left) panel.
        /// </summary>
        Targets,

        /// <summary>
        /// Indicates looking at the comms (up) panel.
        /// </summary>
        Comms,

        /// <summary>
        /// Indicates looking at the roles (down) panel while in the ship. (it makes a difference for certian actions).
        /// </summary>
        RolesShip,

        /// <summary>
        /// Indicates looking at the systems (right) panel.
        /// </summary>
        Systems,

        /// <summary>
        /// Indicates looking at the roles (down) panel while in the srv.
        /// </summary>
        RolesSRV
    }
}