/*
 * unityGB
 * The MIT License (MIT)
 *
 * Copyright (C) 2014 Jonathan Odul (jona@takohi.com)
 *
 * This file is part of unityGB.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System.Collections;

namespace UnityGB
{
	public class SoundChip
	{   
		internal SquareWaveGenerator channel1;
		internal SquareWaveGenerator channel2;
		internal VoluntaryWaveGenerator channel3;
		internal NoiseGenerator channel4;
		internal bool soundEnabled = true;
    
		/** If true, channel is enabled */
		internal bool channel1Enable = true, channel2Enable = true,
			channel3Enable = true, channel4Enable = true;
    
		/** Current sampling rate that sound is output at */
		private int sampleRate = 44100;

    
		/** Initialize sound emulation, and allocate sound hardware */
		public SoundChip()
		{
			channel1 = new SquareWaveGenerator(sampleRate);
			channel2 = new SquareWaveGenerator(sampleRate);
			channel3 = new VoluntaryWaveGenerator(sampleRate);
			channel4 = new NoiseGenerator(sampleRate);
		}
    
		/** Change the sample rate of the playback */
		public void SetSampleRate(int sr)
		{
			sampleRate = sr;
        
			channel1.SetSampleRate(sr);
			channel2.SetSampleRate(sr);
			channel3.SetSampleRate(sr);
			channel4.SetSampleRate(sr);
		}
    
		/** Adds a single frame of sound data to the buffer */
		public void OutputSound(IAudioOutput audioOutput)
		{
			if (soundEnabled)
				return;

			int numChannels = 2; // Always stereo for Game Boy
			int numSamples = audioOutput.GetSamplesAvailable();

			byte[] b = new byte[numChannels * numSamples];

			if (channel1Enable)
				channel1.Play(b, numSamples, numChannels);
			if (channel2Enable)
				channel2.Play(b, numSamples, numChannels);
			if (channel3Enable)
				channel3.Play(b, numSamples, numChannels);
			if (channel4Enable)
				channel4.Play(b, numSamples, numChannels);

			audioOutput.Play(b);
		}
	}
}
