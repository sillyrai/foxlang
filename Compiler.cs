namespace foxlang;

public static class Compiler
{
    static bool IsRegister(string token)
    {
        return token.StartsWith("R");
    }

    static byte ParseRegister(string token)
    {
        token = token.Replace("R", "");
        return byte.Parse(token);
    }
    
    public static void Compile(string code, string filename)
    {
        int index = 0;
        List<byte> bytecode = new List<byte>();
            
        static void WriteOperand(List<byte> bytecode, string token)
        {
            if (IsRegister(token))
            {
                bytecode.Add((byte)OperandType.Register);
                bytecode.Add(ParseRegister(token)); // e.g. "R0" -> 0
            }
            else
            {
                bytecode.Add((byte)OperandType.Literal);
                bytecode.Add(byte.Parse(token)); // e.g. "5" -> 5
            }
        }
            
        foreach (var Line in code.Split('\n'))
        {
            index++;
            string trimmed = Line.Trim();
            if (trimmed.StartsWith(";"))
                continue; // skip comments
            
            string codeOnly = Line.Split(';')[0].Trim();
            if (codeOnly.Length == 0)
                continue;
            
            string[] tokens = codeOnly.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
                continue; // skip blank/whitespace-only lines
            try
            {
                int startAddr = bytecode.Count;
                OpCode op = (OpCode)Enum.Parse(typeof(OpCode), tokens[0]);
                switch (op)
                {
                    case OpCode.MOV: // Move <register> <data/register>
                        if (tokens.Length == 3)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in MOV at line: {index}");
                        break;
                    case OpCode.ADD: // Add <register> <data/register> <data/register>
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in ADD at line: {index}");
                        break;
                    case OpCode.SUB: // Subtract <register> <data/register> <data/register>
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in SUB at line: {index}");
                        break;
                    case OpCode.MUL: // Multiply <register> <data/register> <data/register>
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in MUL at line: {index}");
                        break;
                    case OpCode.DIV: // Divide <register> <data/register> <data/register>
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in DIV at line: {index}");
                        break;
                    case OpCode.POW: // Power <register> <data/register> <data/register>
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in POW at line: {index}");
                        break;
                    case OpCode.OUT: // Print <register>
                        if (tokens.Length == 2)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in OUT at line: {index}");
                        break;
                    case OpCode.EQ:
                    case OpCode.LT:
                    case OpCode.GT:
                        if (tokens.Length == 4)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                            WriteOperand(bytecode, tokens[3]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount at line: {index}");
                        break;
                    
                    case OpCode.JMP: // JMP <address/register>
                        if (tokens.Length == 2)
                        {
                            bytecode.Add((byte)op);
                            WriteOperand(bytecode, tokens[1]); // handles both literal addr and register now
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in JMP at line: {index}");
                        break;
                    
                    case OpCode.JZ: // Jump if zero <register> <address/register>
                        if (tokens.Length == 3)
                        {
                            bytecode.Add((byte)op);
                            bytecode.Add(ParseRegister(tokens[1]));
                            WriteOperand(bytecode, tokens[2]);
                        }
                        else
                            Console.WriteLine($"Invalid operand amount in JZ at line: {index}");
                        break;
                    
                    case OpCode.HALT: // Halts program
                    {
                        if (tokens.Length == 1)
                            bytecode.Add((byte)op);
                        else
                            Console.WriteLine($"Invalid operand amount in HALT at line: {index}");
                        break;
                    }
                    default:
                        Console.WriteLine($"Invalid operand at line: {index}");
                        break;
                }
                Console.WriteLine($"[{startAddr,4} line {index}]: {Line.Trim()}");
            }
            catch
            {
                Console.WriteLine($"{tokens[0]} is not a valid opcode");
            }
        }
            
        File.WriteAllBytes("out.bin", bytecode.ToArray());
    }
}