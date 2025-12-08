using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoPENetConnect
{
    public static class FastLogFormatter
    {
        // 可复用的格式化方法
        public static bool FormatLogLineToCharArray(
                double time,
                double position,
                double load,
                int cycles,
                int halfCycles,
                char[] buffer,
                int offset,
                out int charsWritten)
        {
            charsWritten = 0;
            int pos = offset;

            try
            {
                // 1. 格式化 time (F3)
                if (!FormatDoubleFixed3(time, buffer, ref pos)) return false;

                // 2. ", "
                if (buffer.Length <= pos + 2) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 3. position (F3)
                if (!FormatDoubleFixed3(position, buffer, ref pos)) return false;

                // 4. ", "
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 5. load (F3)
                if (!FormatDoubleFixed3(load, buffer, ref pos)) return false;

                // 6. ", "
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 7. cycles (int)
                if (!FormatInt32(cycles, buffer, ref pos)) return false;

                // 8. ", "
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 9. halfCycles (int)
                if (!FormatInt32(halfCycles, buffer, ref pos)) return false;

                charsWritten = pos - offset;
                return true;
            }
            catch
            {
                // 防止索引越界等异常
                charsWritten = 0;
                return false;
            }
        }

        // 可复用的格式化方法
        public static bool FormatPVLogLineToCharArray(
                double time,
                double maxPos,
                double minPos,
                double maxLoad,
                double minLoad,
                int cycles,
                char[] buffer,
                int offset,
                out int charsWritten)
        {
            charsWritten = 0;
            int pos = offset;

            try
            {
                // 1. 格式化 time (F3)
                if (!FormatDoubleFixed3(time, buffer, ref pos)) return false;

                if (buffer.Length <= pos + 2) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 2. maxPos (F3)
                if (!FormatDoubleFixed3(maxPos, buffer, ref pos)) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 3. minPos (F3)
                if (!FormatDoubleFixed3(minPos, buffer, ref pos)) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 4. maxLoad (F3)
                if (!FormatDoubleFixed3(maxLoad, buffer, ref pos)) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 5. minLoad (F3)
                if (!FormatDoubleFixed3(minLoad, buffer, ref pos)) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                // 6. cycles (int)
                if (!FormatInt32(cycles, buffer, ref pos)) return false;
                buffer[pos++] = ',';
                buffer[pos++] = ' ';

                charsWritten = pos - offset;
                return true;
            }
            catch
            {
                // 防止索引越界等异常
                charsWritten = 0;
                return false;
            }
        }

        // 更高性能：直接写入 StringBuilder 或 Stream（见下方扩展）
        private static bool FormatDoubleFixed3(double value, char[] buffer, ref int pos)
        {
            int start = pos;

            // 处理负数
            if (value < 0)
            {
                if (buffer.Length <= pos) return false;
                buffer[pos++] = '-';
                value = -value;
            }

            // 四舍五入：加 0.0005
            value += 0.0005;
            long total = (long)(value * 1000);
            long integerPart = total / 1000;
            long fractionalPart = total % 1000;

            // 写整数部分
            if (integerPart == 0)
            {
                if (buffer.Length <= pos) return false;
                buffer[pos++] = '0';
            }
            else
            {
                int intStart = pos;
                while (integerPart != 0)
                {
                    if (buffer.Length <= pos) return false;
                    buffer[pos++] = (char)('0' + (integerPart % 10));
                    integerPart /= 10;
                }
                // 反转整数部分
                Array.Reverse(buffer, intStart, pos - intStart);
            }

            // 写小数部分 ".000"
            if (buffer.Length <= pos + 4) return false;
            buffer[pos++] = '.';
            buffer[pos++] = (char)('0' + (fractionalPart / 100));
            buffer[pos++] = (char)('0' + ((fractionalPart / 10) % 10));
            buffer[pos++] = (char)('0' + (fractionalPart % 10));

            return true;
        }

        // 格式化 int32
        private static bool FormatInt32(int value, char[] buffer, ref int pos)
        {
            if (value == 0)
            {
                if (buffer.Length <= pos) return false;
                buffer[pos++] = '0';
                return true;
            }

            if (value < 0)
            {
                if (buffer.Length <= pos) return false;
                buffer[pos++] = '-';
                value = -value;
            }

            int start = pos;
            while (value != 0)
            {
                if (buffer.Length <= pos) return false;
                buffer[pos++] = (char)('0' + (value % 10));
                value /= 10;
            }

            // 反转数字
            Array.Reverse(buffer, start, pos - start);
            return true;
        }

    }
}
