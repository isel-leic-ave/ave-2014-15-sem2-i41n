// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Call
{
}
.module Call.exe

// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit A
       extends [mscorlib]System.Object
{
  .method private hidebysig instance void 
          M() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "A.M()"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method A::M

  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       11 (0xb)
    .maxstack  1
    .locals init (class A V_0)
    IL_0000:  nop
    IL_0001:  ldnull
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  callvirt   instance void A::M()
    IL_0009:  nop
    IL_000a:  ret
  } // end of method A::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method A::.ctor

} // end of class A
