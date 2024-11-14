public class Programmers
{
    private const int SKIP_TIME = 10;
    private static int _videoLength;
    private static int _opStart;
    private static int _opEnd;

    public static void Main(string[] args)
    {

    }

    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
    {
        var answer = "";

        _videoLength = ConvertStringTimeToInt(video_len);
        _opStart = ConvertStringTimeToInt(op_start);
        _opEnd = ConvertStringTimeToInt(op_end);

        var totalTime = ConvertStringTimeToInt(pos);

        foreach (var cmd in commands)
        {

            switch (cmd)
            {
                case "prev":
                    totalTime = (int)MathF.Max(0, totalTime - 10);
                    break;

                case "next":
                    totalTime = (_opStart <= totalTime && totalTime <= _opEnd) ? _opEnd : totalTime;

                    totalTime = (int)MathF.Min(_videoLength, totalTime + 10);
                    break;

                default:
                    return string.Empty;
            }

            totalTime = (_opStart <= totalTime && totalTime <= _opEnd) ? _opEnd : totalTime;

        }

        var min = totalTime / 60;
        var sec = totalTime % 60;
        answer = $"{ConvertIntTimeToString(min)}:{ConvertIntTimeToString(sec)}";

        return answer;
    }

    private static string ConvertIntTimeToString(int time)
    {
        var result = string.Empty;

        if (time < 10)
        {
            result = '0' + time.ToString();
        }
        else
        {
            result = time.ToString();
        }

        return result;
    }

    private static int ConvertStringTimeToInt(string time)
    {
        var timeStr = time.Split(':');
        var min = int.Parse(timeStr[0]) * 60;
        var sec = int.Parse(timeStr[1]);

        return min + sec;
    }
}
