using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum TAB_TYPE
    {
        THEME = 1,
        CARDPACKAGE,
        TRADE
    }

    public enum PACKAGE_TYPE
    {
        NONE = -1,
        NEWTHEME = 1,
        CARDCROWTH,
        CARDGRADE,
        PLAYPACK,
        MILEAGE,
        OTHER
    }

    public enum PRICE_TYPE
    {
        NONE = -1,
        CASH = 1,
        GAM,
        MILEAGEPOINT,
        HIVER,
        FRIENDSHIP
    }

    public enum REWARD_TYPE
    {
        NONE = -1,
        CARD1,
        CARD2,
        MONEYS1,
        MONEYS2,
        MONEYS3,
        MONEYS4
    }
}
