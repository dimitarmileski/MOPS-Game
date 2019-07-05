# MOPS Game
## Проект по предметот Визуелно Програмирање
 
###### Факултет за Информатички Науки и Компјутерско Инженерство - Скопје

### Опис на играта 
МOPS е игра за куче од расата Mops или Pug, кое што се обидува во секој од нивоата да дојде до коската. Притоа избегнувајќи ги препреките и противниците кои се наоѓаат на патот од коската.

### Изглед и опис 



На почетокот на играта има мени.

* Start - Листа на нивоа
* Options - Поставки
* About - Опис
* Exit - Изез од играта

##### Листа на нивоа
На овој поглед има копче за враќање назад кон менито на играта.

Прикажани се сите 15 нивоа кои што се поставени да ја зафаќаат целата ширина на екранот и притоа секој левел да зазема еднаков дел од екранот.

Секое од нивоата може да има две бои. Портокаловоа доколку нивото не е комплетирано и зелена доколу е комплетирано.

Во долниот десен агол има мени за зачувување на игри. Притоа може да се направи нова игра, да се зачува состојбата на моменталната игра, или пак да зачува на друго место моменталната состојба на играта.
 Притоа треба да се зачува состојбата и може потоа да се исклули играта и да се продолжи од каде што сме застанале.

###### Нивоа

Играта има 15 нивоа, и притоа секое од нивоата има различни платформи и различни противници кои треба да се избегнуваат. Секое од нивоата има различна позадинска музика.

Притоа во секое од нивоата брзината на платформите, позицијата на кучето се избира случајно.
 
На секоје од нивоата има копче за враќање на листата со нивоа, копче за вклучување/исклучување на музиката на тоа ниво, опис за контролите на играта.

##### Поставки 
Во делот за поставки се наоѓа копче за вклучување/исклучување на музиката на ниво на менија.


### Имплементација

#### Menu Form
Секоја ставка во менито се отвара во нова форма, како нишка а старата форма се затвора.


 ```csharp
    private Thread th;

     public void openNewForm() {
            this.Close();
            th = new Thread(openNewWinForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

       void openNewWinForm(object obj)
        {
            if (menuItemSelected == MenuItemSelected.Levels)
            {
                Application.Run(new LevelsForm());
            }
            else if (menuItemSelected == MenuItemSelected.Options) {
                Application.Run(new OptionsForm());
            }
            else if(menuItemSelected == MenuItemSelected.About)
            {
                Application.Run(new AboutForm());
            }

        }
```

Прикажување на формите на цел екран

 ```csharp

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
     
```

#### Levels Form

Прикажување на шемата на нивоа

```csharp
 //Levels Picture Box
        private List<PictureBox> levelsBoxes;

//...

 private void LevelsForm_Load(object sender, EventArgs e)
        {

//...

lvlPnl.Size = new Size(this.Width, this.Height / 2);
            lvlPnl.Location = new Point(0, this.Height / 2 - (lvlPnl.Height / 2));

            for (int i = 0; i < levelsBoxes.Count(); i++)
            {
                levelsBoxes[i].Size = new Size(this.Width / 15, this.Height);
            }


            for (int i = 0; i < levelsBoxes.Count(); i++)
            {
                Label label = new Label();

                label.Text = "Level " + (i + 1);

                label.Location = new Point(levelsBoxes[i].Location.X, levelsBoxes[i].Location.Y + levelsBoxes[i].Height / 3);
                label.BringToFront();
                label.Size = new Size(levelsBoxes[i].Width, 80);
                label.BackColor = Color.DarkGray;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Consolas", 10, FontStyle.Bold);
                label.ForeColor = Color.White;
                this.Controls.Add(label);
            }

//...
}


```

#### Options Form
#### About Form
#### Level Form

