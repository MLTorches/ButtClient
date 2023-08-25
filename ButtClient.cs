using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ButtClient
{
    /// <summary>
    /// A framework-independent library for controlling your sex toys (.NET Standard 2.0 compliant).<br/>
    /// Requires the standalone receiver application <a href='https://github.com/MLTorches/ButtServer/releases/latest'>ButtServer</a>.
    /// </summary>
    /// 
    /// <remarks>Implementation-wise, this a transparent wrapper around the <a href='https://github.com/MLTorches/BasicButtManager/releases/latest'>BasicButtManager</a> library,
    /// via the ButtServer proxy.<br/>
    /// The public-facing interface is identical to that of BasicButtManager besides the class name.</remarks>
    public class ButtClient
    {
        private readonly Socket socket;
        private readonly string clientName;

        /// <summary>
        /// Initialize this ButtClient and connect it to the ButtServer.
        /// </summary>
        /// <param name="clientName">Identify this client to the server.</param>
        public ButtClient(String clientName)
        {
            this.clientName = clientName;

            IPHostEntry ipHostInfo = Dns.GetHostEntryAsync("localhost").Result;
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPt = new IPEndPoint(ipAddress, 42069);

            socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipEndPt);
            Send("Connected");
        }

        /// <summary>
        /// Send the specified payload with the client's name prefixed.
        /// </summary>
        /// <param name="payload">The raw message to be sent.</param>
        private void Send(String payload)
        {
            payload = clientName + ' ' + payload + "\n";
            byte[] msg = Encoding.ASCII.GetBytes(payload);
            socket.Send(msg);
        }

        /// <summary>
        /// Directly control your toys with the provided parameters.
        /// </summary>
        /// 
        /// <param name="intensity">Intensity for vibrators, oscillators, rotators, pressurizers, etc.</param>
        /// <param name="position">Position of linear actuators, if omitted will take the value of intensity.</param>
        /// <param name="oscillate">If true, let the linear actuators move automatically at a set speed (based on intensity). Only applicable if position not given.</param>
        /// 
        /// <remarks>It is recommended in most cases to use one of the provided convenient functions instead, most notably Set().</remarks>
        public void Control(float intensity, float position = -1f, bool oscillate = false)
        {
            Send("Control" + ' ' + intensity + ' ' + position + ' ' + oscillate);
        }

        /// <summary>
        /// Vibrate, oscillate, stroke, etc. all connected devices according to the one given intensity value.
        /// </summary>
        /// 
        /// <param name="intensity">The intensity to be applied to all connected toys.</param>
        public void Set(float intensity)
        {
            Send("Set" + ' ' + intensity);
        }

        /// <summary>
        /// Set all toys to the same constant speed AND location.
        /// </summary>
        /// 
        /// <param name="actionValue">The intensity or location to be set to all connected toys.</param>
        public void Press(float actionValue)
        {
            Send("Press" + ' ' + actionValue);
        }

        /// <summary>
        /// Fade the intensity of all toys to a certain point.
        /// </summary>
        /// 
        /// <param name="targetIntensity">The target intensity, can be higher or lower than the current intensity.</param>
        /// <param name="smoothness">Between 0f and 1f, the higher the smoother the transition.</param>
        /// <remarks>Does not support multiple fades at one time.</remarks>
        public void Fade(float targetIntensity, float smoothness = 1f)
        {
            Send("Fade" + ' ' + targetIntensity + ' ' + smoothness);
        }

        /// <summary>
        /// Fade all toys in from zero intensity to max power.
        /// </summary>
        /// 
        /// <remarks>Does not support multiple fades at one time.</remarks>
        public void FadeIn()
        {
            Send("FadeIn");
        }

        /// <summary>
        /// Fade all toys out from max intensity to zero power.
        /// </summary>
        /// 
        /// <remarks>Does not support multiple fades at one time.</remarks>
        public void FadeOut()
        {
            Send("FadeOut");
        }

        /// <summary>
        /// Press for a single buzz/squeeze/stroke/spin.
        /// </summary>
        /// 
        /// <param name="reboundSpeed">How long the action is held before being released, from 0f to 1f.</param>
        /// <remarks>Client must make sure to not pulse too often too quickly (~ once per second is ideal).</remarks>
        public void Pulse(float reboundSpeed)
        {
            Send("Pulse" + ' ' + reboundSpeed);
        }

        /// <summary>
        /// Push all strokers down, buzz vibrators for a bit, then push strokers back up.<br/>
        /// </summary>
        /// 
        /// <param name="reboundSpeed">How long the action is held before being released, from 0f to 1f.</param>
        /// <remarks>Basically the slow version of Pulse().</remarks>
        public void Hold(float reboundSpeed)
        {
            Send("Hold" + ' ' + reboundSpeed);
        }

        /// <summary>
        /// Stop all connected toys.
        /// </summary>
        public void Stop()
        {
            Send("Stop");
        }

        /// <summary>
        /// Stop all connected toys and close server connection.
        /// </summary>
        public void Exit()
        {
            Send("Exit");
        }
        
        /// <summary>
        /// Disconnect this client from the ButtServer.
        /// </summary>
        public void Disconnect()
        {
            Send("Disconnected");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
