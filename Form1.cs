using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textBoxes = {
            {TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB18,TB19},
            {TB21,TB22,TB23,TB24,TB25,TB26,TB27,TB28,TB29},
            {TB31,TB32,TB33,TB34,TB35,TB36,TB37,TB38,TB39},
            {TB41,TB42,TB43,TB44,TB45,TB46,TB47,TB48,TB49},
            {TB51,TB52,TB53,TB54,TB55,TB56,TB57,TB58,TB59},
            {TB61,TB62,TB63,TB64,TB65,TB66,TB67,TB68,TB69},
            {TB71,TB72,TB73,TB74,TB75,TB76,TB77,TB78,TB79},
            {TB81,TB82,TB83,TB84,TB85,TB86,TB87,TB88,TB89},
            {TB91,TB92,TB93,TB94,TB95,TB96,TB97,TB98,TB99},
            };
            for(int i =0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    if (textBoxes[i, j].Enabled == true)
                    {
                        textBoxes[i, j].Text = "";
                    }
                }
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textBoxes = {
            {TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB18,TB19},
            {TB21,TB22,TB23,TB24,TB25,TB26,TB27,TB28,TB29},
            {TB31,TB32,TB33,TB34,TB35,TB36,TB37,TB38,TB39},
            {TB41,TB42,TB43,TB44,TB45,TB46,TB47,TB48,TB49},
            {TB51,TB52,TB53,TB54,TB55,TB56,TB57,TB58,TB59},
            {TB61,TB62,TB63,TB64,TB65,TB66,TB67,TB68,TB69},
            {TB71,TB72,TB73,TB74,TB75,TB76,TB77,TB78,TB79},
            {TB81,TB82,TB83,TB84,TB85,TB86,TB87,TB88,TB89},
            {TB91,TB92,TB93,TB94,TB95,TB96,TB97,TB98,TB99},
            };
            int[,] grid = {
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
            };

            initializeGrid(grid, textBoxes);
            if (checkall(grid))
            {
                MessageBox.Show("Everything is good!");
            }
            else
            {
                MessageBox.Show("Something is wrong!");
            }

        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textBoxes = {
            {TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB18,TB19},
            {TB21,TB22,TB23,TB24,TB25,TB26,TB27,TB28,TB29},
            {TB31,TB32,TB33,TB34,TB35,TB36,TB37,TB38,TB39},
            {TB41,TB42,TB43,TB44,TB45,TB46,TB47,TB48,TB49},
            {TB51,TB52,TB53,TB54,TB55,TB56,TB57,TB58,TB59},
            {TB61,TB62,TB63,TB64,TB65,TB66,TB67,TB68,TB69},
            {TB71,TB72,TB73,TB74,TB75,TB76,TB77,TB78,TB79},
            {TB81,TB82,TB83,TB84,TB85,TB86,TB87,TB88,TB89},
            {TB91,TB92,TB93,TB94,TB95,TB96,TB97,TB98,TB99},
            };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (textBoxes[i, j].Text != "")
                    {
                        textBoxes[i, j].Enabled = false;
                    }
                }
            }

        }
        private void unlockButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textBoxes = {
            {TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB18,TB19},
            {TB21,TB22,TB23,TB24,TB25,TB26,TB27,TB28,TB29},
            {TB31,TB32,TB33,TB34,TB35,TB36,TB37,TB38,TB39},
            {TB41,TB42,TB43,TB44,TB45,TB46,TB47,TB48,TB49},
            {TB51,TB52,TB53,TB54,TB55,TB56,TB57,TB58,TB59},
            {TB61,TB62,TB63,TB64,TB65,TB66,TB67,TB68,TB69},
            {TB71,TB72,TB73,TB74,TB75,TB76,TB77,TB78,TB79},
            {TB81,TB82,TB83,TB84,TB85,TB86,TB87,TB88,TB89},
            {TB91,TB92,TB93,TB94,TB95,TB96,TB97,TB98,TB99},
            };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Enabled = true;
                }
            }
        }

        bool checkall(int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (checkGrid(grid, i, j))
                    {
                        //MessageBox.Show("Everything is good!");
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void initializeGrid(int[,] table, TextBox[,] input)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    {
                        if (input[i, j].Text != "")
                        {
                            table[i, j] = int.Parse(input[i, j].Text);
                        }
                    }
                }
            }
        }

        bool checkGrid(int[,] table, int i, int j)
        {
            //given a coordinate of the grid, check the corresponding row collumn and block
            //return true if everything is good and false if there is an error
            
            //no value yet
            if(table[i,j] == 0)
            {
                return true;
            }

            //checks rows and columns
            for(int a=0; a<9; a++)
            {
                if(table[i,a] == table[i,j] && a != j)
                {
                    return false;
                }
                if(table[a,j] == table[i,j] && a != i)
                {
                    return false;
                }
            }

            //checks box
            int x = findbox(i);
            int y = findbox(j);
            for(int a = x*3; a<x*3+3; a++)
            {
                for(int b = y*3; b<y*3+3; b++)
                {
                    if(table[a,b] == table[i, j] && (a!=i || b!=j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        int findbox(int x)
        {
            if(x < 3)
            {
                return 0;
            }
            if (x < 6)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private void TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        void display(TextBox box, int value)
        {
            box.Text = value.ToString();
        }

        bool solveIt(int[,] grid, TextBox[,] textboxes)
        {
            Stack<int> stk = new Stack<int>();
            int i = 0;
            int j = 0;
            int input = 1;
            bool stop = false;


            while (!stop)
            {
                if (textboxes[i, j].Enabled == true)
                {
                    grid[i, j] = input;
                    if (checkGrid(grid, i, j))   //current input is good
                    {
                        display(textboxes[i, j], input);
                        stk.Push(i);    //saves state
                        stk.Push(j);
                        stk.Push(input);
                        input = 1;      //reset input

                        j++;            //increase position
                        if (j == 9)
                        {
                            i++;
                            j = 0;
                            if (i == 9)
                            {
                                stop = true;
                            }
                        }
                    }
                    else                        //curent input is not good
                    {
                        input++;
                        while (input > 9)
                        {
                            if(stk.Count == 0)
                            {
                                return false;
                            }
                            grid[i, j] = 0;                 //set value = 0 and go back
                            display(textboxes[i, j], 0);
                            input = stk.Pop();
                            j = stk.Pop();
                            i = stk.Pop();
                            input++;
                        }
                    }
                }
                else
                {
                    j++;            //increase position
                    if (j == 9)
                    {
                        i++;
                        j = 0;
                        if (i == 9)
                        {
                            stop = true;
                        }
                    }
                }
            }

            return true;
        }


        private void solveButton_Click(object sender, EventArgs e)
        {
            TextBox[,] textBoxes = {
            {TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB18,TB19},
            {TB21,TB22,TB23,TB24,TB25,TB26,TB27,TB28,TB29},
            {TB31,TB32,TB33,TB34,TB35,TB36,TB37,TB38,TB39},
            {TB41,TB42,TB43,TB44,TB45,TB46,TB47,TB48,TB49},
            {TB51,TB52,TB53,TB54,TB55,TB56,TB57,TB58,TB59},
            {TB61,TB62,TB63,TB64,TB65,TB66,TB67,TB68,TB69},
            {TB71,TB72,TB73,TB74,TB75,TB76,TB77,TB78,TB79},
            {TB81,TB82,TB83,TB84,TB85,TB86,TB87,TB88,TB89},
            {TB91,TB92,TB93,TB94,TB95,TB96,TB97,TB98,TB99},
            };
            int[,] grid = {
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
            };

            initializeGrid(grid, textBoxes);

            if (checkall(grid))
            {
                if (solveIt(grid, textBoxes))
                {
                    MessageBox.Show("Finished!");
                }
                else
                {
                    MessageBox.Show("Cannot be solved");
                }
            }
            else
            {
                MessageBox.Show("Cannot be solved");
            }
        }
    }
}
