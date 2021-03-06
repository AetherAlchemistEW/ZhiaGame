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
using Articy.Unity.Interfaces;
using Articy.Unity;

namespace Articy.Asylumjame.GlobalVariables
{
    
    
    [Articy.Unity.ArticyCodeGenerationHashAttribute(636455869422592606)]
    public class ArticyScriptFragments : BaseScriptFragments, ISerializationCallbackReceiver
    {
        
        #region Fields
        private System.Collections.Generic.Dictionary<int, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>> Conditions = new System.Collections.Generic.Dictionary<int, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
        
        private System.Collections.Generic.Dictionary<int, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>> Instructions = new System.Collections.Generic.Dictionary<int, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
        #endregion
        
        #region Script fragments
        /// <summary>
        /// ObjectID: 0x0
        /// Articy Object ref: articy://localhost/view/ae7bc7d2-82eb-4285-a7ea-e67cf1223fbc/0?pane=selected&amp;tab=current
        /// </summary>
        public void Script_AUTJreDJgEelou7d5rGN0g(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.Items.HasLantern = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x0
        /// Articy Object ref: articy://localhost/view/ae7bc7d2-82eb-4285-a7ea-e67cf1223fbc/0?pane=selected&amp;tab=current
        /// </summary>
        public void Script_nvkfhLSZe0aPyYDjukR5Sw(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.StoryEvents.Chp2_SpokeToFriend = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x0
        /// Articy Object ref: articy://localhost/view/ae7bc7d2-82eb-4285-a7ea-e67cf1223fbc/0?pane=selected&amp;tab=current
        /// </summary>
        public void Script_x2py1C9WHE61sKdRjkRxQ(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.StoryEvents.Chp4_HelpedVillager = true;;
        }
        #endregion
        
        #region Unity serialization
        public void OnBeforeSerialize()
        {
        }
        
        public void OnAfterDeserialize()
        {
            Conditions = new System.Collections.Generic.Dictionary<int, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
            Instructions = new System.Collections.Generic.Dictionary<int, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
            Instructions.Add(1977422282, this.Script_AUTJreDJgEelou7d5rGN0g);
            Instructions.Add(-670664929, this.Script_nvkfhLSZe0aPyYDjukR5Sw);
            Instructions.Add(-237506491, this.Script_x2py1C9WHE61sKdRjkRxQ);
        }
        #endregion
        
        #region Script execution
        public override void CallInstruction(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, int aHash, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Instructions.ContainsKey(aHash) == false))
            {
                return;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            Instructions[aHash].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        
        public override bool CallCondition(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, int aHash, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Conditions.ContainsKey(aHash) == false))
            {
                return true;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            return Conditions[aHash].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        #endregion
    }
}
