using System;
using System.Text;
namespace FourthTask
{
    public class Tensor<T>
    {
        private readonly int[] _dimensions;
        private readonly T[] _data;

        // Constructor that initializes the dimensions array and creates an array of type T with the calculated size.
        public Tensor(params int[] dimensions)
        {
            _dimensions = dimensions;
            _data = new T[CalculateSize(dimensions)];
        }

        // Indexer that gets or sets the element at the specified indices in the tensor data array.
        public T this[params int[] indices]
        {
            get => _data[CalculateIndex(indices)];
            set => _data[CalculateIndex(indices)] = value;
        }

        // Private helper method that calculates the total size of the tensor given its dimensions.
        private int CalculateSize(int[] dimensions)
        {
            int size = 1;
            foreach (var dim in dimensions)
            {
                size *= dim;
            }
            return size;
        }

        // Private helper method that calculates the index of an element in the tensor data array given its indices.
        private int CalculateIndex(int[] indices)
        {
            if (indices.Length != _dimensions.Length)
            {
                throw new ArgumentException("Invalid number of indices.");
            }

            int index = 0;
            int multiplier = 1;
            for (int i = _dimensions.Length - 1; i >= 0; i--)
            {
                if (indices[i] < 0 || indices[i] >= _dimensions[i])
                {
                    throw new ArgumentOutOfRangeException(nameof(indices), "Index out of range.");
                }
                index += indices[i] * multiplier;
                multiplier *= _dimensions[i];
            }
            return index;
        }

        // Overrides the ToString() method to return a string representation of the tensor data.
        public override string ToString()
        {
            if (_dimensions.Length == 0)
            {
                return _data[0].ToString();
            }

            var sb = new StringBuilder();
            var indices = new int[_dimensions.Length];

            // Helper method to append tensor values to a StringBuilder recursively.
            AppendTensorValues(sb, 0, indices);

            return sb.ToString();
        }

        // Private helper method to append tensor values to a StringBuilder recursively.
        private void AppendTensorValues(StringBuilder sb, int dim, int[] indices)
        {
            if (dim == _dimensions.Length - 1)
            {
                for (int i = 0; i < _dimensions[dim]; i++)
                {
                    indices[dim] = i;
                    sb.Append($"\t{this[indices]}");
                    if (i != _dimensions[dim] - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.AppendLine();
            }
            else
            {
                for (int i = 0; i < _dimensions[dim]; i++)
                {
                    indices[dim] = i;
                    string d = "";
                    for (int l = 0; l < dim; l++) d += " ";
                    sb.AppendLine($"{d}Dimension {dim}, index {i}:");
                    AppendTensorValues(sb, dim + 1, indices);
                }
            }
        }

        // Method to fill the tensor with random values between a minimum and maximum value.
        public void FillRandom(T minValue, T maxValue)
        {
            var random = new Random();
            for (int i = 0; i < _data.Length; i++)
            {
                dynamic min = minValue;
                dynamic max = maxValue;
                dynamic range = max - min;
                dynamic randomValue = (dynamic)random.NextDouble() * range + min;
                _data[i] = (T)Convert.ChangeType(randomValue, typeof(T));
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var tensor = new Tensor<int>(2, 2, 2, 2, 3);

            tensor.FillRandom(5, 15);

            Console.WriteLine(tensor);

            Console.ReadLine();
        }
    }
}