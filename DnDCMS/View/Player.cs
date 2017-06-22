using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDCMS.ViewModel;
using DnDCMSLibrary.Logic;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Repositories;


namespace DnDCMS.View
{
    public partial class Player : Form
    {
        SpellViewModel SpellviewModel = new SpellViewModel();
        SpellLogic spell = new SpellLogic(new SpellContext());
        CharacterViewModel CharacterviewModel = new CharacterViewModel();
        CharacterLogic character = new CharacterLogic(new CharacterContext());

        public Player()
        {
            InitializeComponent();
            CharacterviewModel.Characters = character.GetCharacter();
            cbPCCharacterName.Items.AddRange(CharacterviewModel.Characters.ToArray());
        }
        /* CharacterSheet */
        private void cbPCCharacterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCharacterInfoFields();
        }
        /* Spellbook */
        private void btnPCSearchSpell_Click(object sender, EventArgs e)
        {
            string query = CreateQuery();
            lbPCSpellList.DataSource = (spell.GetSpell(query));
        }

        private void lbPCSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSpellbookFields();
        }

        /* Methods */

        public void SetCharacterInfoFields()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                CharacterviewModel.SelectedCharacter = CharacterviewModel.Characters.Find(x => x.name.Contains(cbPCCharacterName.Text));
            }
            int ArmorClass = 10;
            cbPCRace.Text = CharacterviewModel.SelectedCharacter.race;
            cbPCSubrace.Text = CharacterviewModel.SelectedCharacter.subrace;
            cbPCAlignment.Text = CharacterviewModel.SelectedCharacter.alignment;
            cbPCBackground.Text = CharacterviewModel.SelectedCharacter.background;
            tbPCHairColor.Text = CharacterviewModel.SelectedCharacter.haircolor;
            tbPCEyeColor.Text = CharacterviewModel.SelectedCharacter.eyecolor;
            tbPCSkinColor.Text = CharacterviewModel.SelectedCharacter.skincolor;
            cbPCGender.Text = CharacterviewModel.SelectedCharacter.gender;
            tbPCHeight.Text = CharacterviewModel.SelectedCharacter.height;
            tbPCWeight.Text = CharacterviewModel.SelectedCharacter.weight;
            nudPCAge.Value = CharacterviewModel.SelectedCharacter.age;
            nudPCExp.Value = CharacterviewModel.SelectedCharacter.experience;
            nudPCHP.Value = CharacterviewModel.SelectedCharacter.currenthp;
            nudPCHPMax.Value = CharacterviewModel.SelectedCharacter.maxhp;
            cbPCGender.Text = CharacterviewModel.SelectedCharacter.gender;

        }
        public void SetSpellbookFields()
        {
            Spell selectedspell = (Spell)lbPCSpellList.SelectedItem;
            tbPCSelectedSpellName.Text = selectedspell.name;
            tbPCSelectedSpellRange.Text = selectedspell.range;
            tbPCSelectedSpellType.Text = selectedspell.type;
            tbPCSelectedSpellLevel.Text = selectedspell.level.ToString();
            tbPCSelectedSpellDuration.Text = selectedspell.duration;
            tbPCSelectedSpellCastingTime.Text = selectedspell.castingtime;
            rtbPCSelectedSpellComponents.Text = selectedspell.components;
            rtbPCSelectedSpellEffect.Text = selectedspell.effect;
        }
        public string CreateQuery()
        {
            string query = "";
            if (tbPCSearchSpellName.Text != "")
            {
                query = "WHERE name LIKE %" + tbPCSearchSpellName.Text + "%";
            }
            if (cbPCSearchSpellClass.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND " + cbPCSearchSpellClass.Text + " = TRUE";
                }
                else
                {
                    query = "WHERE " + cbPCSearchSpellClass.Text + " = TRUE";
                }
            }
            if (cbPCSearchSpellLevel.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND spelllevel = " + "'" + cbPCSearchSpellLevel.Text + "'";
                }
                else
                {
                    query = "WHERE spelllevel = " + "'" + cbPCSearchSpellLevel.Text + "'";
                }
            }
            if (cbPCSearchSpellType.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND spelltype = " + "'" + cbPCSearchSpellType.Text + "'";
                }
                else
                {
                    query = "WHERE spelltype = " + "'" + cbPCSearchSpellType.Text + "'";
                }
            }
            if (chbPCSearchSpellRitual.Checked)
            {
                if (query != "")
                {
                    query = query + " AND ritual = " + chbPCSearchSpellRitual.Checked;
                }
                else
                {
                    query = "WHERE ritual = " + chbPCSearchSpellRitual.Checked;
                }
            }
            return query;
        }


    }
}
