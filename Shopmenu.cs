using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpringandeGris
{
    class Shopmenu:SuperMenu
    {

        // Ny kommentar. 

        //Konstruktorn
        public Shopmenu(Texture2D shopmenuTexture, Texture2D normalButtonTexture, Texture2D lookingButtonTexture)
        {
            buttonLista.Add(new SuperButtons(normalButtonTexture, lookingButtonTexture, new Vector2(50, 150)));
            buttonLista.Add(new SuperButtons(normalButtonTexture, lookingButtonTexture, new Vector2(50, 250)));
            buttonLista.Add(new SuperButtons(normalButtonTexture, lookingButtonTexture, new Vector2(50, 350)));
            menuTexture = shopmenuTexture;
        }

        public Gamestates Update()
        {
            // Vad metoden gör beskirvs i SuperMenus.
            GettingNewValues();

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                keysUsed = true;
            }

            foreach (SuperButtons shopButton in buttonLista)
            {
                if (nowMouseState.Position != lastMouseState.Position)
                {
                    keysUsed = false;
                }

                if (keysUsed == false)
                {
                    shopButton.MouseOnButton();

                    // Vad metoden gör beskrivs i SuperMenus klassen.
                    ButtonListForloop();

                    //Nedan ändras gamestatens

                    if (buttonLista[2].MouseOnButton() == ButtonLook.clickingButton)
                    {
                        return Gamestates.startmenu;
                    }

                    lastMouseState = nowMouseState;
                }
            }


            if (FirtButtonActive() == true)
            {
                valdKnapp++;
                buttonLista[valdKnapp].Update(ButtonLook.lookingButton);
                buttonLista[1].Update(ButtonLook.normalButton);
                buttonLista[2].Update(ButtonLook.normalButton);
            }

            if (ClickCombo(nowButtonState, lastButtonState) == ClickCombos.up && valdKnapp >= 0)
            {
                buttonLista[valdKnapp].Update(ButtonLook.normalButton);
                valdKnapp--;

                if (valdKnapp == -1)
                    valdKnapp++;

                buttonLista[valdKnapp].Update(ButtonLook.lookingButton);
            }

            if (ClickCombo(nowButtonState, lastButtonState) == ClickCombos.down && valdKnapp <= 2 && gammalValdKnapp != -1)
            {
                buttonLista[valdKnapp].Update(ButtonLook.normalButton);
                valdKnapp++;

                if (valdKnapp == 3)
                    valdKnapp--;

                buttonLista[valdKnapp].Update(ButtonLook.lookingButton);
            }

            // Nedan ändras gamstatsen beroende på vilken knapp man "aktiverar"
            #region Gamestates retunering
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && valdKnapp == 2 && lastButtonState != nowButtonState)
            {
                ResetingButtos();
                return Gamestates.startmenu;
            } 
            
            else
            {
                lastButtonState = nowButtonState;
                return Gamestates.shopmenu;
            }
            #endregion
        }

    }
}
