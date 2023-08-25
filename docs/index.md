
# Butt Client ![Smiling Peach](https://camo.githubusercontent.com/82d932c73232f2fa5afaad48b74c5c16d659ba1a138b56e6965777356370c025/68747470733a2f2f6d6c746f72636865732e6769746875622e696f2f4261736963427574744d616e616765722f7265736f75726365732f66617669636f6e32342e706e67)

The framework-agnostic, user-friendly library for your adult toys integration needs!

## Usage

To set all your machines to half intensity:

1. Launch [Intiface :copyright: Central](https://intiface.com/central/) and connect your toys.
1. Launch [ButtServer](https://github.com/MLTorches/ButtServer/releases/latest).
3. Add this [NuGet](https://www.nuget.org/packages/ButtClient/) package to your project.
4. Somewhere in your code...

```
ButtClient client = new ButtClient("ClientName");
client.Set(0.5f);
client.Disconnect();
```

This a transparent wrapper around the [BasicButtManager](https://github.com/MLTorches/BasicButtManager) library, via the [ButtServer](https://github.com/MLTorches/ButtServer) proxy. The public-facing interface is identical to that of BasicButtManager besides the class name.

## Wiki
Click [here](https://mltorches.github.io/ButtClient/api/ButtClient.ButtClient.html) to view the documentation!

## Credits
Buttplug: [qdot@github.com](https://github.com/qdot) | Favicon: [freepik@flaticon.com](https://www.flaticon.com/authors/frdmn)

## License

This project is BSD 3-Clause licensed.

```text
Copyright (c) 2023, MLTorches
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of the copyright holder nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```