// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.Asylumjame.Features;

namespace Articy.Asylumjame
{
    
    
    public class DefaultSupportingCharacterTemplate : Entity, IEntity, IPropertyProvider, IObjectWithFeatureDefaultBasicCharacterFeature
    {
        
        [SerializeField()]
        private ArticyValueDefaultSupportingCharacterTemplateTemplate mTemplate = new ArticyValueDefaultSupportingCharacterTemplateTemplate();
        
        private static Articy.Asylumjame.Templates.DefaultSupportingCharacterTemplateTemplateConstraint mConstraints = new Articy.Asylumjame.Templates.DefaultSupportingCharacterTemplateTemplateConstraint();
        
        public Articy.Asylumjame.Templates.DefaultSupportingCharacterTemplateTemplate Template
        {
            get
            {
                return mTemplate.GetValue();
            }
            set
            {
                mTemplate.SetValue(value);
            }
        }
        
        public static Articy.Asylumjame.Templates.DefaultSupportingCharacterTemplateTemplateConstraint Constraints
        {
            get
            {
                return mConstraints;
            }
        }
        
        public DefaultBasicCharacterFeatureFeature GetFeatureDefaultBasicCharacterFeature()
        {
            return Template.DefaultBasicCharacterFeature;
        }
        
        protected override void CloneProperties(object aClone)
        {
            DefaultSupportingCharacterTemplate newClone = ((DefaultSupportingCharacterTemplate)(aClone));
            if ((Template != null))
            {
                newClone.Template = ((Articy.Asylumjame.Templates.DefaultSupportingCharacterTemplateTemplate)(Template.CloneObject()));
            }
            base.CloneProperties(newClone);
        }
        
        public override bool IsLocalizedPropertyOverwritten(string aProperty)
        {
            return base.IsLocalizedPropertyOverwritten(aProperty);
        }
        
        #region property provider interface
        public override void setProp(string aProperty, object aValue)
        {
            if (aProperty.Contains("."))
            {
                Template.setProp(aProperty, aValue);
                return;
            }
            base.setProp(aProperty, aValue);
        }
        
        public override Articy.Unity.Interfaces.ScriptDataProxy getProp(string aProperty)
        {
            if (aProperty.Contains("."))
            {
                return Template.getProp(aProperty);
            }
            return base.getProp(aProperty);
        }
        #endregion
    }
}
