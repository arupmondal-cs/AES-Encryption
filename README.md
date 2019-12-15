## Advanced Encryption Standard (AES) Encryption Scheme

.NET provides high level classes for various encryption algorithms, both symmetric and asymmetric. [Advanced Encryption Standard (AES)](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard) is one of the symmetric encryption algorithms that allows both parties, sender and receiver, to use the same key to encrypt and decrypt data.

The **Advanced Encryption Standard (AES)**, also known by its original name **Rijndael** is a specification for the encryption of electronic data established by the U.S. National Institute of Standards and Technology (NIST) in 2001.

AES is a subset of the Rijndael block cipher  developed by two Belgian cryptographers, **Vincent Rijmen** and **Joan Daemen**, who submitted a proposal to NIST during the AES selection process. Rijndael is a family of ciphers with different key and block sizes.

AES is based on a design principle known as a substitution–permutation network, and is efficient in both software and hardware. Unlike its predecessor DES, AES does not use a Feistel network. AES is a variant of Rijndael which has a fixed block size of 128 bits, and a key size of 128, 192, or 256 bits. By contrast, Rijndael per se is specified with block and key sizes that may be any multiple of 32 bits, with a minimum of 128 and a maximum of 256 bits.

## Compile and Run
  
  Writing C# Programs on Linux:
  
  Mono is an open-source version of the .NET Framework which includes a C# compiler and runs on several operating systems, including various flavors of Linux and Mac OS. Check for [Mono](https://www.mono-project.com/download/stable/).
  
  To Compile:
  
  > **mcs AES.cs**
  
  The compiler will create **"AES.exe"**, which you can run using:
  
  > **mono AES.exe**
  
  
  ## Execution with Pictures
  
  The output looks like the following where you can type any text that will be encrypted and decrypted.
  
  ![Compile-Run](https://github.com/arupmondal-cs/AES-Encryption/blob/master/Picture/compile-run.png)
