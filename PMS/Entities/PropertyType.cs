using System;
namespace PMS.Entities
{
    /// <summary>
    /// To hold the type of a property be it a land or built duplex so we can do
    /// ProperType.Bungalow etc
    /// </summary>
    public enum PropertyType
	{
		Land,
        Duplex,
        Bungalow,
        TwoStories,
        ThreeStories,
        TwoBeds,
        ThreeBeds,
        Misc
    }
}

