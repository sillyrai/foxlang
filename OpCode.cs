namespace foxlang;

public enum OpCode : byte
{
    MOV = 0x01, // Move
    ADD = 0x02, // Add
    SUB = 0x03, // Subtract
    MUL = 0x04, // Multiply
    DIV = 0x05, // Divide
    POW = 0x06, // Power
    OUT = 0x07, // Out (print to console)
    
    EQ = 0x08, // Equals
    LT = 0x09, // Less than
    GT = 0x0A, // Greater than
    JMP = 0x0B, // Jump
    JZ = 0x0C, // Jump if zero (basically if statement)
    HALT = 0xFF, // Halt (end process)
}