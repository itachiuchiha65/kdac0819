﻿select [LoggedIn], [LoggedOut],DATEDIFF(MINUTE, LoggedIn,LoggedOut) from T_TimeLog