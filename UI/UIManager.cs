using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Assets.Scripts.UI
{
    public class UIManager : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<UIManager, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits { }

        Dictionary<UIThemes.ColorThemeGroup, List<ThemedVisElement>> visElementColorGroups;

        #region elements
        // populated as soon as first UI updates... Problably fine.
        
        // Background
        private ThemedVisElement m_Background = new ThemedVisElement();
        
        // Status Icons (top right)
        private ThemedVisElement m_ShipStatusIndicator = new ThemedVisElement();
        private ThemedVisElement m_ToMapButton = new ThemedVisElement();
        private ThemedVisElement m_PersonellIcon = new ThemedVisElement();
        private ThemedVisElement m_SkillsIcon = new ThemedVisElement();
        private ThemedVisElement m_LocationLevelText = new ThemedVisElement();

        // Location Buttons (A to Z == Top to Bottom)
        private ThemedVisElement m_ChangeLocIconA = new ThemedVisElement();
        private ThemedVisElement m_ChangeLocIconB = new ThemedVisElement();
        private ThemedVisElement m_ChangeLocIconC = new ThemedVisElement();
        private ThemedVisElement m_ChangeLocIconD = new ThemedVisElement();

        // Action Buttons (A to Z == Left to Right)
        private ThemedVisElement m_LocActionIconA = new ThemedVisElement();
        private ThemedVisElement m_LocActionIconB = new ThemedVisElement();
        private ThemedVisElement m_LocActionIconC = new ThemedVisElement();
        private ThemedVisElement m_LocActionIconD = new ThemedVisElement();

        // center view
        private ThemedVisElement m_SpeakerScrollView = new ThemedVisElement();
        private ThemedVisElement m_ActionDivider = new ThemedVisElement();
        private ThemedVisElement m_ActionDividerContainer = new ThemedVisElement();

        // Location context (top left)
        private ThemedVisElement m_locNameText = new ThemedVisElement();
        private ThemedVisElement m_charNameText = new ThemedVisElement();

        // Currency (A to Z == Left to Right)
        private ThemedVisElement m_currencyIconA = new ThemedVisElement();
        private ThemedVisElement m_currencyTextA = new ThemedVisElement();
        private ThemedVisElement m_currencyIconB = new ThemedVisElement();
        private ThemedVisElement m_currencyTextB = new ThemedVisElement();
        #endregion

        public UIManager()
        {
   
            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
            visElementColorGroups = AssignThemedVisElementColorGroups();

            // AssignIconVisElements();
        }
        

        #region groupings
        public Dictionary<UIThemes.ColorThemeGroup, List<ThemedVisElement>> AssignThemedVisElementColorGroups()
        {
           
            Dictionary<UIThemes.ColorThemeGroup, List<ThemedVisElement>> groups = new Dictionary<UIThemes.ColorThemeGroup, List<ThemedVisElement>>() {
                { UIThemes.ColorThemeGroup.PrimaryColor, new List<ThemedVisElement>() },
                { UIThemes.ColorThemeGroup.SecondaryColor, new List<ThemedVisElement>() },
                { UIThemes.ColorThemeGroup.TertiaryColor, new List<ThemedVisElement>() },
                { UIThemes.ColorThemeGroup.BackgroundColor, new List<ThemedVisElement>() },
            };
            
            // Color Group A
            groups[UIThemes.ColorThemeGroup.PrimaryColor].AddRange(new List<ThemedVisElement> {
                m_ChangeLocIconA,
                m_ChangeLocIconB,
                m_ChangeLocIconC,
                m_ChangeLocIconD,
                
                m_LocActionIconA,
                m_LocActionIconB,
                m_LocActionIconC,
                m_LocActionIconD,

                m_ToMapButton,
                m_ShipStatusIndicator
            });

            // Color Group B
            groups[UIThemes.ColorThemeGroup.SecondaryColor].AddRange(new List<ThemedVisElement> {
                m_currencyIconA,
                m_currencyIconB,
                m_currencyTextA,
                m_currencyTextB,

                m_locNameText,
                m_charNameText,

                m_ActionDivider,

                m_PersonellIcon,
                m_SkillsIcon,
                m_LocationLevelText
            });

            groups[UIThemes.ColorThemeGroup.TertiaryColor].AddRange(new List<ThemedVisElement> {
                
            });

            groups[UIThemes.ColorThemeGroup.BackgroundColor].AddRange(new List<ThemedVisElement> {
                m_Background
            });
            return groups;
        }
        #endregion

        // God help me, Unity...
        public void OnGeometryChanged(GeometryChangedEvent evt)
        {
            // Unfortunely, UI Kit currently requires us to map each id manually...
            // may be worth removing the ternary to force crash on id query miss?
            m_Background.SetElement(this?.Q("gameview-bg"), ThemedVisElement.VisEleColorType.backgroundVisEle);

            m_ShipStatusIndicator.SetElement(this?.Q("ship-status-vis-indicator"), ThemedVisElement.VisEleColorType.SVGElement);
            m_ToMapButton.SetElement( this?.Q("to-map-button"), ThemedVisElement.VisEleColorType.SVGElement);
            m_PersonellIcon.SetElement( this?.Q("personnel-icon"), ThemedVisElement.VisEleColorType.SVGElement);
            m_SkillsIcon.SetElement( this?.Q("skills-icon"), ThemedVisElement.VisEleColorType.SVGElement);
            m_LocationLevelText.SetElement(this?.Q<Label>("level-text"), ThemedVisElement.VisEleColorType.text);

            m_ChangeLocIconA.SetElement(this?.Q("change-loc-button-a"), ThemedVisElement.VisEleColorType.SVGElement);
            m_ChangeLocIconB.SetElement(this?.Q("change-loc-button-b"), ThemedVisElement.VisEleColorType.SVGElement);
            m_ChangeLocIconC.SetElement(this?.Q("change-loc-button-c"), ThemedVisElement.VisEleColorType.SVGElement);
            m_ChangeLocIconD.SetElement(this?.Q("change-loc-button-d"), ThemedVisElement.VisEleColorType.SVGElement);

            m_LocActionIconA.SetElement(this?.Q("action-button-a"), ThemedVisElement.VisEleColorType.SVGElement);
            m_LocActionIconB.SetElement(this?.Q("action-button-b"), ThemedVisElement.VisEleColorType.SVGElement);
            m_LocActionIconC.SetElement(this?.Q("action-button-c"), ThemedVisElement.VisEleColorType.SVGElement);
            m_LocActionIconD.SetElement(this?.Q("action-button-d"), ThemedVisElement.VisEleColorType.SVGElement);

            m_SpeakerScrollView.SetElement(this?.Q<ScrollView>("speaker-scrollview"), ThemedVisElement.VisEleColorType.backgroundVisEle);
            m_ActionDivider.SetElement(this?.Q("response-horizontal-rule"), ThemedVisElement.VisEleColorType.backgroundVisEle);
            // parent of actual element controls width
            m_ActionDividerContainer.SetElement(this?.Q("response-divider-container"), ThemedVisElement.VisEleColorType.backgroundVisEle); 

            m_locNameText.SetElement(this?.Q<Label>("loc-name-text"), ThemedVisElement.VisEleColorType.text);
            m_charNameText.SetElement(this?.Q<Label>("portrait-name-text"), ThemedVisElement.VisEleColorType.text);

            m_currencyIconA.SetElement(this?.Q("currency-a-icon"), ThemedVisElement.VisEleColorType.SVGElement); 
            m_currencyTextA.SetElement(this?.Q<Label>("currency-a-amt"), ThemedVisElement.VisEleColorType.text);
            m_currencyIconB.SetElement(this?.Q("currency-b-icon"), ThemedVisElement.VisEleColorType.SVGElement); 
            m_currencyTextB.SetElement(this?.Q<Label>("currency-b-amt"), ThemedVisElement.VisEleColorType.text);

            //m_PersonellIcon.SetElement(this?.Q("personell-icon"), ThemedVisElement.VisEleColorType.SVGElement);

            // for quick test, remove
            UIThemes.LoadEngineeringVisualTheme(visElementColorGroups);
        }
        
        
        // todo -> switch based on an enum
        private void OnUpdateColorScheme()
        {
            UIThemes.LoadEngineeringVisualTheme(visElementColorGroups);
        }

    }

}

