using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace machineTuring
{
    public partial class About : Form
    {
        public About()
        {
            
            InitializeComponent();
            textAboutApp.Text = "Машина Тьюринга - Абстрактный исполнитель.\n Была предложена Аланом Тьюрингом в 1936 " +
                "году для формализации понятия алгоритма. \n Машина Тьюринга является расширением конечного автомата и," +
                " согласно тезису Чёрча - Тьюринга, \n способна имитировать всех исполнителей, каким-либо образом" +
                " реализующих процесс пошагового вычисления, \n в котором каждый шаг вычисления достаточно элементарен.";
            instructionsText.Text = "Данное приложение поддерживает следующий вид ввода значений \n  в таблицу: \n" +
                "оператор из алфавита \n сдвиг индекса: <, >, . \n номер столбца \n Пример: |<2";
        }

    }
}
