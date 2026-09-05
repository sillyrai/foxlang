namespace foxlang;

public static class Interpreter
{
    public static void Run(byte[] bytecode)
        {
            Dictionary<int, int> registers = new Dictionary<int, int>();
            int ip = 0; // instruction pointer
            
            while (ip < bytecode.Length)
            {
                byte opcodeByte = bytecode[ip];
                switch ((OpCode)opcodeByte)
                {
                    case OpCode.MOV: // [opcode][register][operandType][operandValue]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType = bytecode[ip + 2];
                        byte operandValue = bytecode[ip + 3];

                        registers[destReg] = operandType == (byte)OperandType.Register
                            ? registers[operandValue]
                            : operandValue;

                        ip += 4;
                        break;
                    }

                    case OpCode.ADD: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 + regVal2;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.MUL: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 * regVal2;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.SUB: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 - regVal2;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.DIV: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 / regVal2;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.POW: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] = (int)Math.Pow(regVal1, regVal2);

                        ip += 6;
                        break;
                    }

                    case OpCode.EQ: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 == regVal2 ? 1 : 0;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.LT: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 < regVal2 ? 1 : 0;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.GT: // [opcode][register][operandType1][operandValue1][operandType2][operandValue2]
                    {
                        byte destReg = bytecode[ip + 1];
                        byte operandType1 = bytecode[ip + 2];
                        byte operandValue1 = bytecode[ip + 3];
                        byte operandType2 = bytecode[ip + 4];
                        byte operandValue2 = bytecode[ip + 5];
                        
                        int regVal1 = operandType1 == (byte)OperandType.Register ? registers[operandValue1] : operandValue1;
                        int regVal2 = operandType2 == (byte)OperandType.Register ? registers[operandValue2] : operandValue2;
                        
                        registers[destReg] =  regVal1 > regVal2 ? 1 : 0;

                        ip += 6;
                        break;
                    }
                    
                    case OpCode.JMP: // [opcode][operandType][operandValue]
                    {
                        byte operandType = bytecode[ip + 1];
                        byte operandValue = bytecode[ip + 2];

                        int regVal = operandType == (byte)OperandType.Register ? registers[operandValue] : operandValue;
                        ip = regVal;
                        
                        break;
                    }
                    
                    case OpCode.JZ: // [opcode][register][operandType][operandValue]
                    {
                        byte register = bytecode[ip + 1];
                        byte operandType = bytecode[ip + 2];
                        byte operandValue = bytecode[ip + 3];

                        int regVal = registers[register];
                        int jzAddress = operandType == (byte)OperandType.Register ? registers[operandValue] : operandValue;

                        ip = (regVal == 0) ? jzAddress : ip + 4;
                        break;
                    }
                    
                    case OpCode.OUT: // [opcode][register]
                    {
                        byte destReg = bytecode[ip + 1];
                        int value = registers[destReg];
                        Console.WriteLine($"[REGISTER {destReg}] = {value}");
                        ip += 2;
                        break;
                    }

                    case OpCode.HALT: // [opcode]
                        return; 

                    default:
                        Console.WriteLine("what did u do...");
                        ip++;
                        break;
                }
            }
        }
}