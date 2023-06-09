using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PR12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            result.ColumnCount = 3;
            result.RowCount = 3;

            mat_A.ColumnCount = 3;
            mat_A.RowCount = 3;

            mat_B.ColumnCount = 3;
            mat_B.RowCount = 3;
        }







        public double[,] TransposeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Create a new matrix with the rows and cols flipped
            double[,] transposedMatrix = new double[cols, rows];

            // Loop through each row and column to transpose the data
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Transpose the data from the original matrix to the new matrix
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }

            // Return the transposed matrix
            return transposedMatrix;
        }


        public double[,] GetDataGridViewData(DataGridView dgv)
        {
            // Determine the number of rows and columns in the DataGridView
            int numRows = dgv.Rows.Count;
            int numCols = dgv.Columns.Count;

            // Create a 2D array to hold the cell data
            double[,] data = new double[numRows, numCols];

            // Loop through each row and column to retrieve the cell data
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    data[i, j] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value);
                }
            }

            // Return the cell data as a 2D array
            return data;
        }

        public void SetDataGridViewData(DataGridView dgv, double[,] data)
        {
            // Determine the number of rows and columns in the DataGridView
            int numRows = dgv.Rows.Count;
            int numCols = dgv.Columns.Count;
            Console.WriteLine(numRows.ToString() + " " + numCols.ToString());

            // Loop through each row and column to set the cell data
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    // Check if the current index is within the bounds of the data array
                    if (i < data.GetLength(0) && j < data.GetLength(1))
                    {
                        dgv.Rows[i].Cells[j].Value = data[i, j];
                    }
                    else
                    {
                        Console.WriteLine("Error: Index out of bounds - i=" + i.ToString() + ", j=" + j.ToString());
                    }
                }
            }
        }


        private void ClearAllCells(DataGridView dgv)
        {
            // Clear all cells in mat_A
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dgv.Rows[i].Cells[j].Value = "";
                }
            }
        }



        public double[,] MultiplyMatrixByScalar(DataGridView dgv, double scalar)
        {
            int numRows = dgv.Rows.Count;
            int numCols = dgv.Columns.Count;

            // Create a 2D array to hold the cell data
            double[,] matrix = GetDataGridViewData(dgv);

            double[,] result = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    result[i, j] = scalar * matrix[i, j];
                }
            }

            return result;
        }




        public void matrixSumming(DataGridView f1, DataGridView f2, DataGridView t)
                {
                    // Sum the matrices and store the result in mat_C
                    for (int i = 0; i < f1.Rows.Count; i++)
                    {
                        for (int j = 0; j < f1.Columns.Count; j++)
                        {
                            int val_A = Convert.ToInt32(f1.Rows[i].Cells[j].Value);
                            int val_B = Convert.ToInt32(f2.Rows[i].Cells[j].Value);
                            int val_C = val_A + val_B;
                            t.Rows[i].Cells[j].Value = val_C;
                        }
                    }


                }

        public void matrixMultiply(DataGridView f1, DataGridView f2, DataGridView t)
        {
            // Sum the matrices and store the result in mat_C
            for (int i = 0; i < f1.Rows.Count; i++)
            {
                for (int j = 0; j < f1.Columns.Count; j++)
                {
                    int val_A = Convert.ToInt32(f1.Rows[i].Cells[j].Value);
                    int val_B = Convert.ToInt32(f2.Rows[i].Cells[j].Value);
                    int val_C = val_A * val_B;
                    t.Rows[i].Cells[j].Value = val_C;
                }
            }


        }

        public void matrixSub(DataGridView f1, DataGridView f2, DataGridView t)
        {
            // Sum the matrices and store the result in mat_C
            for (int i = 0; i < f1.Rows.Count; i++)
            {
                for (int j = 0; j < f1.Columns.Count; j++)
                {
                    int val_A = Convert.ToInt32(f1.Rows[i].Cells[j].Value);
                    int val_B = Convert.ToInt32(f2.Rows[i].Cells[j].Value);
                    int val_C = val_A - val_B;
                    t.Rows[i].Cells[j].Value = val_C;
                }
            }


        }

        public void InvertMatrix(DataGridView dgv, DataGridView dgvTo)
        {
            // Get the data from the DataGridView
            double[,] data = GetDataGridViewData(dgv);

            // Check that the matrix is square
            int numRows = dgv.Rows.Count;
            int numCols = dgv.Columns.Count;
            if (numRows != numCols)
            {
                throw new Exception("Matrix must be square.");
            }

            // Create a copy of the original matrix to work with
            double[,] matrix = new double[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = Convert.ToDouble(data[i, j]);
                }
            }

            // Initialize the inverse matrix as the identity matrix
            double[,] inverse = new double[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (i == j)
                    {
                        inverse[i, j] = 1.0;
                    }
                    else
                    {
                        inverse[i, j] = 0.0;
                    }
                }
            }

            // Perform Gaussian elimination on the matrix and its inverse
            for (int k = 0; k < numRows; k++)
            {
                double pivot = matrix[k, k];
                if (pivot == 0.0)
                {
                    throw new Exception("Matrix is singular."+pivot);
                }

                for (int j = 0; j < numCols; j++)
                {
                    matrix[k, j] /= pivot;
                    inverse[k, j] /= pivot;
                }

                for (int i = 0; i < numRows; i++)
                {
                    if (i == k)
                    {
                        continue;
                    }

                    double factor = matrix[i, k];
                    for (int j = 0; j < numCols; j++)
                    {
                        matrix[i, j] -= factor * matrix[k, j];
                        inverse[i, j] -= factor * inverse[k, j];
                    }
                }
            }

            // Set the inverted values back to the DataGridView
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    dgvTo.Rows[i].Cells[j].Value = inverse[i, j];
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            matrixSumming(mat_A, mat_B, result);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //trasfer grid data from mat_A to mat_B
            
            SetDataGridViewData(mat_B, GetDataGridViewData(mat_A));
            ClearAllCells(mat_A);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //trasfer grid data from mat_B to mat_A
            
            SetDataGridViewData(mat_A, GetDataGridViewData(mat_B));
            ClearAllCells(mat_B);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //trasfer grid data from result to mat_B
            SetDataGridViewData(mat_B, GetDataGridViewData(result));
            ClearAllCells(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            matrixMultiply(mat_A, mat_B, result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            matrixSub(mat_A, mat_B, result);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InvertMatrix(mat_A,result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int columns = (int)numericUpDown2.Value;
            int rows = (int)numericUpDown1.Value;
            mat_A.ColumnCount = columns;
            mat_A.RowCount = rows;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int columns = (int)numericUpDown3.Value;
            int rows = (int)numericUpDown4.Value;
            mat_B.ColumnCount = columns;
            mat_B.RowCount = rows;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Get a matrix from the DataGridView
            double[,] matrix = GetDataGridViewData(mat_A);

            // Transpose the matrix
            double[,] transposedMatrix = TransposeMatrix(matrix);

            // Set the transposed matrix back into the DataGridView
            SetDataGridViewData(result, transposedMatrix);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Get a matrix from the DataGridView
            double[,] matrix = GetDataGridViewData(mat_A);


            // Create a new 1x1 result array containing the rank of the matrix
            matrix[0, 0] = GetMatrixRank(matrix);

            // Set the result DataGridView to contain the rank of the matrix
            SetDataGridViewData(result, matrix);
        }


        private void mat_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public double[,] GetMinorMatrix(DataGridView dgv, int row, int col)
        {
            int numRows = dgv.Rows.Count;
            int numCols = dgv.Columns.Count;

            // Create a 2D array to hold the cell data
            double[,] matrix = GetDataGridViewData(dgv);
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int m = 0, k;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    result[m, k++] = matrix[i, j];
                }
                m++;
            }
            return result;
        }

        public static double CalculateDeterminant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
    
            if (n == 1)
            {
                return matrix[0, 0];
            }
            else if (n == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else if (n == 3)
            {
                return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[2, 1] * matrix[1, 2]) 
                     - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[2, 0] * matrix[1, 2])
                     + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[2, 0] * matrix[1, 1]);
            }
            else
            {
                throw new ArgumentException("Matrix order not supported");
            }
        }


        public static int GetMatrixRank(double[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            // Perform row reduction using Gaussian elimination
            for (int i = 0; i < numRows; i++)
            {
                int pivotRow = i;
                while (pivotRow < numRows && matrix[pivotRow, i] == 0)
                {
                    pivotRow++;
                }

                if (pivotRow == numRows)
                {
                    break;
                }

                if (pivotRow != i)
                {
                    // Swap rows
                    for (int j = 0; j < numCols; j++)
                    {
                        double temp = matrix[i, j];
                        matrix[i, j] = matrix[pivotRow, j];
                        matrix[pivotRow, j] = temp;
                    }
                }

                double pivot = matrix[i, i];

                for (int j = i + 1; j < numRows; j++)
                {
                    double factor = matrix[j, i] / pivot;

                    for (int k = i + 1; k < numCols; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }

                    matrix[j, i] = 0;
                }
            }

            int rank = numRows;

            // Count number of non-zero rows
            for (int i = 0; i < numRows; i++)
            {
                bool isZeroRow = true;

                for (int j = 0; j < numCols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isZeroRow = false;
                        break;
                    }
                }

                if (isZeroRow)
                {
                    rank--;
                }
            }

            return rank;
        }




        private void button11_Click(object sender, EventArgs e)
        {
            // Get a matrix from the DataGridView
            double[,] matrix = GetDataGridViewData(mat_A);

            double determ = CalculateDeterminant(matrix);


            // Create a new 1x1 result array containing the rank of the matrix
            matrix[0, 0] = determ;

            // Set the result DataGridView to contain the rank of the matrix
            SetDataGridViewData(result, matrix);
        }

        private void button12_Click(object sender, EventArgs e)
        {

            double[,] minorDet = GetMinorMatrix(mat_A, 0, 0);


            // Set the result DataGridView to contain the rank of the matrix
            SetDataGridViewData(result, minorDet);
        }

        private void button13_Click(object sender, EventArgs e)
        {
                double[,] matrix = GetDataGridViewData(mat_A);
                double[,] matrix2 = GetDataGridViewData(mat_B);

                double[,] Multiply = MultiplyMatrixByScalar(mat_A, matrix2[0,0]);


                // Set the result DataGridView to contain the rank of the matrix
                SetDataGridViewData(result, Multiply);
            }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}