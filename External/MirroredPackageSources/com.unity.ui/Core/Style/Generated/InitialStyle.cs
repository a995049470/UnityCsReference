/******************************************************************************/
//
//                             DO NOT MODIFY
//          This file has been generated by the UIElementsGenerator tool
//              See InitialStyleCsGenerator class for details
//
/******************************************************************************/
namespace UnityEngine.UIElements.StyleSheets
{
    internal static class InitialStyle
    {
        private static ComputedStyle s_InitialStyle = ComputedStyle.CreateUninitialized();

        public static ComputedStyle Get()
        {
            return s_InitialStyle;
        }

        static InitialStyle()
        {
            s_InitialStyle.nonInheritedData.alignContent = Align.FlexStart;
            s_InitialStyle.nonInheritedData.alignItems = Align.Stretch;
            s_InitialStyle.nonInheritedData.alignSelf = Align.Auto;
            s_InitialStyle.nonInheritedData.backgroundColor = Color.clear;
            s_InitialStyle.nonInheritedData.backgroundImage = default(Background);
            s_InitialStyle.nonInheritedData.borderBottomColor = Color.clear;
            s_InitialStyle.nonInheritedData.borderBottomLeftRadius = 0f;
            s_InitialStyle.nonInheritedData.borderBottomRightRadius = 0f;
            s_InitialStyle.nonInheritedData.borderBottomWidth = 0f;
            s_InitialStyle.nonInheritedData.borderLeftColor = Color.clear;
            s_InitialStyle.nonInheritedData.borderLeftWidth = 0f;
            s_InitialStyle.nonInheritedData.borderRightColor = Color.clear;
            s_InitialStyle.nonInheritedData.borderRightWidth = 0f;
            s_InitialStyle.nonInheritedData.borderTopColor = Color.clear;
            s_InitialStyle.nonInheritedData.borderTopLeftRadius = 0f;
            s_InitialStyle.nonInheritedData.borderTopRightRadius = 0f;
            s_InitialStyle.nonInheritedData.borderTopWidth = 0f;
            s_InitialStyle.nonInheritedData.bottom = StyleKeyword.Auto.ToLength();
            s_InitialStyle.inheritedData.color = Color.black;
            s_InitialStyle.nonInheritedData.cursor = default(Cursor);
            s_InitialStyle.nonInheritedData.display = DisplayStyle.Flex;
            s_InitialStyle.nonInheritedData.flexBasis = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.flexDirection = FlexDirection.Column;
            s_InitialStyle.nonInheritedData.flexGrow = 0f;
            s_InitialStyle.nonInheritedData.flexShrink = 1f;
            s_InitialStyle.nonInheritedData.flexWrap = Wrap.NoWrap;
            s_InitialStyle.inheritedData.fontSize = 0f;
            s_InitialStyle.nonInheritedData.height = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.justifyContent = Justify.FlexStart;
            s_InitialStyle.nonInheritedData.left = StyleKeyword.Auto.ToLength();
            s_InitialStyle.inheritedData.letterSpacing = 0f;
            s_InitialStyle.nonInheritedData.marginBottom = 0f;
            s_InitialStyle.nonInheritedData.marginLeft = 0f;
            s_InitialStyle.nonInheritedData.marginRight = 0f;
            s_InitialStyle.nonInheritedData.marginTop = 0f;
            s_InitialStyle.nonInheritedData.maxHeight = StyleKeyword.None.ToLength();
            s_InitialStyle.nonInheritedData.maxWidth = StyleKeyword.None.ToLength();
            s_InitialStyle.nonInheritedData.minHeight = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.minWidth = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.opacity = 1f;
            s_InitialStyle.nonInheritedData.overflow = OverflowInternal.Visible;
            s_InitialStyle.nonInheritedData.paddingBottom = 0f;
            s_InitialStyle.nonInheritedData.paddingLeft = 0f;
            s_InitialStyle.nonInheritedData.paddingRight = 0f;
            s_InitialStyle.nonInheritedData.paddingTop = 0f;
            s_InitialStyle.nonInheritedData.position = Position.Relative;
            s_InitialStyle.nonInheritedData.right = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.textOverflow = TextOverflow.Clip;
            s_InitialStyle.inheritedData.textShadow = default(TextShadow);
            s_InitialStyle.nonInheritedData.top = StyleKeyword.Auto.ToLength();
            s_InitialStyle.nonInheritedData.unityBackgroundImageTintColor = Color.white;
            s_InitialStyle.nonInheritedData.unityBackgroundScaleMode = ScaleMode.StretchToFill;
            s_InitialStyle.inheritedData.unityFont = default(Font);
            s_InitialStyle.inheritedData.unityFontDefinition = default(FontDefinition);
            s_InitialStyle.inheritedData.unityFontStyleAndWeight = FontStyle.Normal;
            s_InitialStyle.nonInheritedData.unityOverflowClipBox = OverflowClipBox.PaddingBox;
            s_InitialStyle.inheritedData.unityParagraphSpacing = 0f;
            s_InitialStyle.nonInheritedData.unitySliceBottom = 0;
            s_InitialStyle.nonInheritedData.unitySliceLeft = 0;
            s_InitialStyle.nonInheritedData.unitySliceRight = 0;
            s_InitialStyle.nonInheritedData.unitySliceTop = 0;
            s_InitialStyle.inheritedData.unityTextAlign = TextAnchor.UpperLeft;
            s_InitialStyle.inheritedData.unityTextOutlineColor = Color.clear;
            s_InitialStyle.inheritedData.unityTextOutlineWidth = 0f;
            s_InitialStyle.nonInheritedData.unityTextOverflowPosition = TextOverflowPosition.End;
            s_InitialStyle.inheritedData.visibility = Visibility.Visible;
            s_InitialStyle.inheritedData.whiteSpace = WhiteSpace.Normal;
            s_InitialStyle.nonInheritedData.width = StyleKeyword.Auto.ToLength();
            s_InitialStyle.inheritedData.wordSpacing = 0f;
        }

        public static Align alignContent => s_InitialStyle.nonInheritedData.alignContent;
        public static Align alignItems => s_InitialStyle.nonInheritedData.alignItems;
        public static Align alignSelf => s_InitialStyle.nonInheritedData.alignSelf;
        public static Color backgroundColor => s_InitialStyle.nonInheritedData.backgroundColor;
        public static Background backgroundImage => s_InitialStyle.nonInheritedData.backgroundImage;
        public static Color borderBottomColor => s_InitialStyle.nonInheritedData.borderBottomColor;
        public static Length borderBottomLeftRadius => s_InitialStyle.nonInheritedData.borderBottomLeftRadius;
        public static Length borderBottomRightRadius => s_InitialStyle.nonInheritedData.borderBottomRightRadius;
        public static float borderBottomWidth => s_InitialStyle.nonInheritedData.borderBottomWidth;
        public static Color borderLeftColor => s_InitialStyle.nonInheritedData.borderLeftColor;
        public static float borderLeftWidth => s_InitialStyle.nonInheritedData.borderLeftWidth;
        public static Color borderRightColor => s_InitialStyle.nonInheritedData.borderRightColor;
        public static float borderRightWidth => s_InitialStyle.nonInheritedData.borderRightWidth;
        public static Color borderTopColor => s_InitialStyle.nonInheritedData.borderTopColor;
        public static Length borderTopLeftRadius => s_InitialStyle.nonInheritedData.borderTopLeftRadius;
        public static Length borderTopRightRadius => s_InitialStyle.nonInheritedData.borderTopRightRadius;
        public static float borderTopWidth => s_InitialStyle.nonInheritedData.borderTopWidth;
        public static Length bottom => s_InitialStyle.nonInheritedData.bottom;
        public static Color color => s_InitialStyle.inheritedData.color;
        public static Cursor cursor => s_InitialStyle.nonInheritedData.cursor;
        public static DisplayStyle display => s_InitialStyle.nonInheritedData.display;
        public static Length flexBasis => s_InitialStyle.nonInheritedData.flexBasis;
        public static FlexDirection flexDirection => s_InitialStyle.nonInheritedData.flexDirection;
        public static float flexGrow => s_InitialStyle.nonInheritedData.flexGrow;
        public static float flexShrink => s_InitialStyle.nonInheritedData.flexShrink;
        public static Wrap flexWrap => s_InitialStyle.nonInheritedData.flexWrap;
        public static Length fontSize => s_InitialStyle.inheritedData.fontSize;
        public static Length height => s_InitialStyle.nonInheritedData.height;
        public static Justify justifyContent => s_InitialStyle.nonInheritedData.justifyContent;
        public static Length left => s_InitialStyle.nonInheritedData.left;
        public static Length letterSpacing => s_InitialStyle.inheritedData.letterSpacing;
        public static Length marginBottom => s_InitialStyle.nonInheritedData.marginBottom;
        public static Length marginLeft => s_InitialStyle.nonInheritedData.marginLeft;
        public static Length marginRight => s_InitialStyle.nonInheritedData.marginRight;
        public static Length marginTop => s_InitialStyle.nonInheritedData.marginTop;
        public static Length maxHeight => s_InitialStyle.nonInheritedData.maxHeight;
        public static Length maxWidth => s_InitialStyle.nonInheritedData.maxWidth;
        public static Length minHeight => s_InitialStyle.nonInheritedData.minHeight;
        public static Length minWidth => s_InitialStyle.nonInheritedData.minWidth;
        public static float opacity => s_InitialStyle.nonInheritedData.opacity;
        public static OverflowInternal overflow => s_InitialStyle.nonInheritedData.overflow;
        public static Length paddingBottom => s_InitialStyle.nonInheritedData.paddingBottom;
        public static Length paddingLeft => s_InitialStyle.nonInheritedData.paddingLeft;
        public static Length paddingRight => s_InitialStyle.nonInheritedData.paddingRight;
        public static Length paddingTop => s_InitialStyle.nonInheritedData.paddingTop;
        public static Position position => s_InitialStyle.nonInheritedData.position;
        public static Length right => s_InitialStyle.nonInheritedData.right;
        public static TextOverflow textOverflow => s_InitialStyle.nonInheritedData.textOverflow;
        public static TextShadow textShadow => s_InitialStyle.inheritedData.textShadow;
        public static Length top => s_InitialStyle.nonInheritedData.top;
        public static Color unityBackgroundImageTintColor => s_InitialStyle.nonInheritedData.unityBackgroundImageTintColor;
        public static ScaleMode unityBackgroundScaleMode => s_InitialStyle.nonInheritedData.unityBackgroundScaleMode;
        public static Font unityFont => s_InitialStyle.inheritedData.unityFont;
        public static FontDefinition unityFontDefinition => s_InitialStyle.inheritedData.unityFontDefinition;
        public static FontStyle unityFontStyleAndWeight => s_InitialStyle.inheritedData.unityFontStyleAndWeight;
        public static OverflowClipBox unityOverflowClipBox => s_InitialStyle.nonInheritedData.unityOverflowClipBox;
        public static Length unityParagraphSpacing => s_InitialStyle.inheritedData.unityParagraphSpacing;
        public static int unitySliceBottom => s_InitialStyle.nonInheritedData.unitySliceBottom;
        public static int unitySliceLeft => s_InitialStyle.nonInheritedData.unitySliceLeft;
        public static int unitySliceRight => s_InitialStyle.nonInheritedData.unitySliceRight;
        public static int unitySliceTop => s_InitialStyle.nonInheritedData.unitySliceTop;
        public static TextAnchor unityTextAlign => s_InitialStyle.inheritedData.unityTextAlign;
        public static Color unityTextOutlineColor => s_InitialStyle.inheritedData.unityTextOutlineColor;
        public static float unityTextOutlineWidth => s_InitialStyle.inheritedData.unityTextOutlineWidth;
        public static TextOverflowPosition unityTextOverflowPosition => s_InitialStyle.nonInheritedData.unityTextOverflowPosition;
        public static Visibility visibility => s_InitialStyle.inheritedData.visibility;
        public static WhiteSpace whiteSpace => s_InitialStyle.inheritedData.whiteSpace;
        public static Length width => s_InitialStyle.nonInheritedData.width;
        public static Length wordSpacing => s_InitialStyle.inheritedData.wordSpacing;
    }
}