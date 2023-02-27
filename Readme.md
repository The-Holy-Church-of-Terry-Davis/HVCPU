# Holy Virtual CPU Runtime/Driver

This project is mainly for my C# OS that I'm working on,
however, it made sense to publish the source code as a
separate repository due to the fact that it was easily
portable to C#'s standard libraries.

This source code can be built and ran as a runtime service
for HVCPU binaries, or, it can be used as a library to read,
and execute them from within your own applications.

# Building

You should build the project inside of the NHVCPU if you want
to run the HVCPU Runtime. You can also import it into your own
program if you want to spawn instances of the Engine in your
own programs.

# Support

The HVCPU runtime will be/is compatible with Windows, Mac,
and Linux devices. There will eventually be releases for
the runtime, but for now you will have to pull <a href="https://github.com/The-Holy-Church-of-Terry-Davis/HVCPU/tree/main/NHVCPU/">this code</a>
and build it yourself.

The HVCPU driver is essentially the HVCPU runtime ported
to UEFI. I have purposefully not used any of the C# standard 
libraries so that this project could be ported to UEFI.
There is a NoRuntimeEngine object that you will need to spawn 
to create a driver instance in your program. You will have to
call it from your own program, however, all the bindings are
there! (Including the ones for <a href="https://github.com/MichalStrehovsky/zerosharp/blob/master/efi-no-runtime/zerosharp.cs">UEFI</a>)