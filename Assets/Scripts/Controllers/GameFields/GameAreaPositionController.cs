using System.Collections.Generic;
using AnimalCatcher.Utils;
using UnityEngine;

namespace AnimalCatcher.Controllers
{
    public class GameAreaPositionController : MonoBehaviour, IPatrolGetter
    {
        [Header("Area Borders")] 
        [SerializeField] private Vector2 topLeftBorderPoint;
        [SerializeField] private Vector2 topRightBorderPoint;
        [Space]
        [SerializeField] private Vector2 bottomBorderPoint;
        [Space] 
        [SerializeField, Range(0, 10)] private int matrixSize;
        
        private Vector2[,] _matrixCenters;

        private void Awake()
        {
            GenerateMatrix();
        }

        public Vector2[] GetRandomPositionsArray()
        {
            Vector2[] randomMatrixPoints = GetTwoRandomMatrixPoints();
            
            return new Vector2[] { GenerateRandomPoint(), randomMatrixPoints[0], randomMatrixPoints[1] };
        }

        private Vector2 GenerateRandomPoint()
        {
            float x = UnityRandom.GetRandomFloat(topLeftBorderPoint.x, topRightBorderPoint.x);
            float y = UnityRandom.GetRandomFloat(bottomBorderPoint.y, topLeftBorderPoint.y);
            
            return new Vector2(x, y);
        }
        
        private Vector2[] GetTwoRandomMatrixPoints()
        {
            int index1 = UnityRandom.GetRandomInt(0, matrixSize * matrixSize);
            int index2;
            
            List<int> usedIndices = new List<int>();
            usedIndices.Add(index1);
            
            do
            {
                index2 = UnityRandom.GetRandomInt(0, matrixSize * matrixSize);
            } while (usedIndices.Contains(index2));
            
            int row1 = index1 / matrixSize;
            int col1 = index1 % matrixSize;

            int row2 = index2 / matrixSize;
            int col2 = index2 % matrixSize;
            
            return new Vector2[] { _matrixCenters[row1, col1], _matrixCenters[row2, col2] };
        }
        
        private void GenerateMatrix()
        {
            _matrixCenters = new Vector2[matrixSize, matrixSize];
            
            float cellWidth = (topRightBorderPoint.x - topLeftBorderPoint.x) / matrixSize;
            float cellHeight = (bottomBorderPoint.y - topLeftBorderPoint.y) / matrixSize;
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    float x = topLeftBorderPoint.x + cellWidth * (i + 0.5f);
                    float y = bottomBorderPoint.y - cellHeight * (j + 0.5f);
                    _matrixCenters[i, j] = new Vector2(x, y);
                }
            }
        }
    }   
}