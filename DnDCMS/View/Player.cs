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
using DnDCMSLibrary.Interfaces;



namespace DnDCMS.View
{
    public partial class Player : Form
    {
        /* ViewModels */
        SpellViewModel SpellviewModel = new SpellViewModel();
        CharacterViewModel CharacterviewModel = new CharacterViewModel();
        AbilityScoreViewModel AbilityScoreviewModel = new AbilityScoreViewModel();
        SkillViewModel SkillviewModel = new SkillViewModel();
        ClassViewModel ClassviewModel = new ClassViewModel();

        /* Logics */
        SpellLogic spell = new SpellLogic(new SpellContext());
        CharacterLogic character = new CharacterLogic(new CharacterContext());
        AbilityScoreLogic abilityscore = new AbilityScoreLogic(new AbilityScoreContext());
        SkillLogic skill = new SkillLogic(new SkillContext());
        ClassLogic classs = new ClassLogic(new ClassContext());

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
            SetAbilityScores();
            SetSpeedPerRace();
            SetSkills();
            SetLevel();
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
        public void SetAbilityScores()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                AbilityScoreviewModel.AbilityScores = abilityscore.GetAbilityScores(CharacterviewModel.SelectedCharacter.id);
                AbilityScoreviewModel.SelectedAbilityScore = AbilityScoreviewModel.AbilityScores[0];
            }
            nudPCStrength.Value = AbilityScoreviewModel.SelectedAbilityScore.strength;
            nudPCDexterity.Value = AbilityScoreviewModel.SelectedAbilityScore.dexterity;
            nudPCConstitution.Value = AbilityScoreviewModel.SelectedAbilityScore.constitution;
            nudPCIntelligence.Value = AbilityScoreviewModel.SelectedAbilityScore.intelligence;
            nudPCWisdom.Value = AbilityScoreviewModel.SelectedAbilityScore.wisdom;
            nudPCCharisma.Value = AbilityScoreviewModel.SelectedAbilityScore.charisma;
            tbPCStrengthMod.Text = StrengthModifier(nudPCStrength.Value).ToString();
            tbPCDexterityMod.Text = DexModifier(nudPCDexterity.Value).ToString();
            tbPCConstitutionMod.Text = ConModifier(nudPCConstitution.Value).ToString();
            tbPCIntelligenceMod.Text = IntModifier(nudPCIntelligence.Value).ToString();
            tbPCWisdomMod.Text = WisModifier(nudPCWisdom.Value).ToString();
            tbPCCharismaMod.Text = ChaModifier(nudPCCharisma.Value).ToString();
        }
        public void SetSpeedPerRace()
        {
            if (CharacterviewModel.SelectedCharacter.subrace == "Wood Elf")
            {
                nudPCSpeed.Value = 35;
            }
            else if (CharacterviewModel.SelectedCharacter.race == "Dwarf" || CharacterviewModel.SelectedCharacter.race == "Halfing" || CharacterviewModel.SelectedCharacter.race == "Gnome")
            {
                nudPCSpeed.Value = 25;
            }
            else
            {
                nudPCSpeed.Value = 30;

            }
        }
        public void SetSkills()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                SkillviewModel.Skills = skill.GetSkills(CharacterviewModel.SelectedCharacter.id);
                SkillviewModel.SelectedSkill = SkillviewModel.Skills[0];
            }
            chbPCAcrobatics.Checked = SkillviewModel.SelectedSkill.acrobatics;
            chbPCAnimalHandling.Checked = SkillviewModel.SelectedSkill.animalhandling;
            chbPCArcana.Checked = SkillviewModel.SelectedSkill.arcana;
            chbPCAthletics.Checked = SkillviewModel.SelectedSkill.athletics;
            chbPCDeception.Checked = SkillviewModel.SelectedSkill.deception;
            chbPCHistory.Checked = SkillviewModel.SelectedSkill.history;
            chbPCInsight.Checked = SkillviewModel.SelectedSkill.insight;
            chbPCIntimidation.Checked = SkillviewModel.SelectedSkill.intimidation;
            chbPCInvestigation.Checked = SkillviewModel.SelectedSkill.investigation;
            chbPCMedicine.Checked = SkillviewModel.SelectedSkill.medicine;
            chbPCNature.Checked = SkillviewModel.SelectedSkill.nature;
            chbPCPerception.Checked = SkillviewModel.SelectedSkill.perception;
            chbPCPerformance.Checked = SkillviewModel.SelectedSkill.performance;
            chbPCPersuasion.Checked = SkillviewModel.SelectedSkill.persuasion;
            chbPCReligion.Checked = SkillviewModel.SelectedSkill.religion;
            chbPCSlightOfHand.Checked = SkillviewModel.SelectedSkill.sleightofhand;
            chbPCStealth.Checked = SkillviewModel.SelectedSkill.stealth;
            chbPCSurvival.Checked = SkillviewModel.SelectedSkill.survival;
        }

        public void SetLevel()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                ClassviewModel.Class = classs.GetClass(CharacterviewModel.SelectedCharacter.id);
                ClassviewModel.SelectedClass = ClassviewModel.Class[0];
            }
            nudPCBarbarian.Value = ClassviewModel.SelectedClass.Barbarian;
            nudPCBard.Value = ClassviewModel.SelectedClass.Bard;
            nudPCCleric.Value = ClassviewModel.SelectedClass.Cleric;
            nudPCDruid.Value = ClassviewModel.SelectedClass.Druid;
            nudPCFighter.Value = ClassviewModel.SelectedClass.Fighter;
            nudPCMonk.Value = ClassviewModel.SelectedClass.Monk;
            nudPCPaladin.Value = ClassviewModel.SelectedClass.Paladin;
            nudPCRanger.Value = ClassviewModel.SelectedClass.Ranger;
            nudPCRogue.Value = ClassviewModel.SelectedClass.Rogue;
            nudPCSorcerer.Value = ClassviewModel.SelectedClass.Sorcerer;
            nudPCWarlock.Value = ClassviewModel.SelectedClass.Warlock;
            nudPCWizard.Value = ClassviewModel.SelectedClass.Wizard;
            tbPCLevel.Text = Totallevel().ToString();
        }
        public int Totallevel()
        {
            int totallevel = ClassviewModel.SelectedClass.Barbarian + ClassviewModel.SelectedClass.Bard + ClassviewModel.SelectedClass.Cleric + ClassviewModel.SelectedClass.Druid + ClassviewModel.SelectedClass.Fighter + ClassviewModel.SelectedClass.Monk + ClassviewModel.SelectedClass.Paladin + ClassviewModel.SelectedClass.Ranger + ClassviewModel.SelectedClass.Rogue + ClassviewModel.SelectedClass.Sorcerer + ClassviewModel.SelectedClass.Warlock + ClassviewModel.SelectedClass.Wizard;
            return totallevel;
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
        public decimal StrengthModifier(decimal strength)
        {
            decimal strengthmod;

            strengthmod = strength / 2 - 5;
            strengthmod = Math.Floor(strengthmod);

            return strengthmod;

        }
        public decimal DexModifier(decimal dex)
        {
            decimal dexmod;

            dexmod = dex / 2 - 5;
            dexmod = Math.Floor(dexmod);

            return dexmod;

        }
        public decimal ConModifier(decimal con)
        {
            decimal conmod;

            conmod = con / 2 - 5;
            conmod = Math.Floor(conmod);

            return conmod;

        }
        public decimal IntModifier(decimal intelligence)
        {
            decimal intmod;

            intmod = intelligence / 2 - 5;
            intmod = Math.Floor(intmod);

            return intmod;

        }
        public decimal WisModifier(decimal wis)
        {
            decimal wismod;

            wismod = wis / 2 - 5;
            wismod = Math.Floor(wismod);

            return wismod;

        }
        public decimal ChaModifier(decimal cha)
        {
            decimal chamod;

            chamod = cha / 2 - 5;
            chamod = Math.Floor(chamod);

            return chamod;

        }
    }
}
