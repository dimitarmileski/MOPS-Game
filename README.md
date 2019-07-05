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
Секоја ставка во менито се отвара во нова форма, како нишка а старата форма се затвора. Каде што MenuItemSelected е енумерација.


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

### Прикажување на формите на цел екран

 ```csharp

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
     
```

#### Levels Form

### Прикажување на шемата на нивоа

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

Double buffering 

```csharp

 protected override CreateParams CreateParams // this activates DB and removes flickering and tearing!
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }
```

#### Options Form

### Вклучување и исклучување на музиката.
OptionsForm.cs

```csharp

if (!chkSound.Checked) {
                GameSound.stopGameTheme();
               
            }
            else
            {
                GameSound.playGameTheme();
                
            }

```


```csharp

GameSound.cs

    public static class GameSound
    {
        public static System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();
        public static System.Media.SoundPlayer win = new System.Media.SoundPlayer();
        public static System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();

        public static bool isSoundOn;

        public static void playGameTheme()
        {
            backgroundSound.SoundLocation = "GameThemeSong.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";

            backgroundSound.PlayLooping();
        }

        public static void stopGameTheme() {
            backgroundSound.Stop();
        }

    
```

#### Level Form

Музика на секој од нивоата се имплементира со помош на System.Media.SoundPlayer() класата. 


```csharp

System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();
        System.Media.SoundPlayer win = new System.Media.SoundPlayer();
        System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();

//...

```

### Победа 

```csharp

 if (isWin == true)
            {
 backgroundSound.Stop();
 win.Play();
 System.Threading.Thread.Sleep(900);

isWin = false;
backgroundSound.Play();

}

```

При победа се запира позадинската музика, се пушта позадинската музика. По 900 милисекунди повторно се пушта позадинската музика.

### Пораз

```csharp

if (isCatched == true) //game over (when in contact with badGuy
            {               
                backgroundSound.Stop();
                gameOver.Play();

            }
```

Позиционирање на случајни позиции на блоковите, противници, играч

```csharp

private void initPositions()
        {
            Star.Location = new Point(this.Width-(this.Width/6), 5);

            Random rnd = new Random();

            block0.Location = new Point(rnd.Next(100, this.Width - 100), 420);
            bad_guy.Location = new Point(block0.Location.X /2, block0.Location.Y - bad_guy.Height);

            block1.Location = new Point(rnd.Next(100, this.Width - 100), 320);
            block2.Location = new Point(rnd.Next(100, this.Width - 100), 220);
            block3.Location = new Point(rnd.Next(100, this.Width - 100), 120);
            block4.Location = new Point(rnd.Next(100, this.Width - 100), 20);
            block5.Location = new Point(rnd.Next(100, this.Width - 100), 520);
            block6.Location = new Point(rnd.Next(100, this.Width - 100), 620);
            block7.Location = new Point(rnd.Next(100, this.Width - 100), 720);

            player.Location = new Point(rnd.Next(100, this.Width - 100), this.Height - player.Height);
        }

 ```

### Анимација на играчот во зависност од состојбата

```csharp

  if (left == false && right == false && jump == false) { player.Image = Image.FromFile("dogstanding.gif"); } //standing 
            if (left == true && jump == true) { player.Image = Image.FromFile("dogleftjump.gif"); } //jumping to the left side
            if (right == true && jump == true) { player.Image = Image.FromFile("dogrightjump.gif"); } //jumping to the right side
            if (left == true && jump == false && glitch == false) { player.Image = Image.FromFile("dogwalkingleft.gif"); glitch = true; } //moving to the left side
            if (right == true && jump == false && glitch == false) { player.Image = Image.FromFile("dogwalkingright.gif"); glitch = true; } //moving to the right side
            if (left == false && right == false && jump == true) { player.Image = Image.FromFile("dogjump.gif"); } //jumping on one place

```

### Движење на играчот

Движењето се имплементира со помош на Left, Right, Top property на player кое е PictureBox. Left, Right, Top се растојанија од горниот, левиот и деснот раб на прозорецот со горниот, левиот и десниот раб на player соодветно.

```csharp

   if (right == true) //player moving right
            {
                player.Left += 6;
            }

            if (left == true) //player moving left
            {
                player.Left -= 6;
            }

            if (jump == true) //falling (if player jumped)
            {
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; // does not fall tru bottom!
                jump = false;
            }

            else
            {
                player.Top += 5; // just falling/gravity
            }

            // player side (window) collision
            if (player.Right > screen.Right) //right wall
            {
                player.Left = screen.Width - player.Width;
                right = false;
            }

            if (player.Left < screen.Left) //left wall
            {
                player.Left = screen.Left;
                left = false;
            }
            //

```

### Движење на блоковите 

Постојат два типови на блокови, кои што се разликуваат според според правецот во кои инициално се движат, како и брзината на движење.

Пример за движење на еден блок.



```csharp

            if (block1.Right > screen.Right)
            {
                block1.Left = screen.Width - block1.Width;
                check1 = false;
            }

            if (block1.Left < screen.Left)
            {
                block1.Left = screen.Left;
                check1 = true;
            }

            if (check1 == true)
            {
                block1.Left += (2 + platformSpeed1);
                if (player.Bottom == block1.Top)
                {
                    player.Left += (2 + platformSpeed1);
                }
            }

            else
            {
                block1.Left -= (2 + platformSpeed1);
                if (player.Bottom == block1.Top)
                {
                    player.Left -= (2 + platformSpeed1);
                }
            }

```

### Интеракција со тастатура

Имплементирани се двата методи KeyDown() и КеyUp() на секоја Level форма. Овие два методи добро работат, но се појавува проблем со стрелките на тастатурата, кои може да не работат. Постојат неколку начини ова да се реши, но според препораката на Microsoft треба да се имплементира методот PreviewKeyDownEvent. 

[Control.PreviewKeyDown Event](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.previewkeydown?redirectedfrom=MSDN&view=netframework-4.8)


```csharp

private void Lvl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true; }

            if (e.KeyCode == Keys.Left) { left = true; }

            if (e.KeyCode == Keys.Escape) {
                this.Close();
                th = new Thread(openNewWinForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                }
            }

            if (e.KeyCode == Keys.Enter) {
                this.Close();
                th = new Thread(restartForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }


        private void Lvl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; glitch = false; }

            if (e.KeyCode == Keys.Left) { left = false; glitch = false; }

            if (e.KeyCode == Keys.Space) { glitch = false; }
        }


        private void Lvl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

```
