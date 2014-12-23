using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.AssetsLibrary;

namespace Concur.Sample.ClientLibrary
{
	public class AssetLibraryReadStream : Stream
	{
		/// <summary>
		/// A readonly stream to access an Asset resource
		/// see http://msdn.microsoft.com/en-us/library/system.io.stream.aspx
		/// </summary>
		public AssetLibraryReadStream(ALAssetRepresentation assetRep)
		{
			this.AssetRep = assetRep;
			this.Position = 0;
		}
			
		protected ALAssetRepresentation AssetRep {set; get;}

		public override void Flush() { /* do nothing */ }

		/// <summary>
		/// Read into the specified buffer from offset, the count number of bytes.
		/// see http://msdn.microsoft.com/en-us/library/system.io.stream.read.aspx
		/// </summary>
		public override int Read(byte[] buffer, int offset, int count)
		{
			if(buffer == null) throw new ArgumentNullException("buffer");
			if(offset < 0) throw new ArgumentOutOfRangeException("offset", offset, "parameter cannot be negative");
			if(count < 0) throw new ArgumentOutOfRangeException("count", count, "parameter cannot be negative");

			NSError nsError;
			int bytesRead;

			unsafe
			{
				fixed (byte* pointer = buffer)
				{
					bytesRead = (int)AssetRep.GetBytes((IntPtr)(pointer + offset), (long)Position, (uint)count, out nsError);
				}
			}

			if (nsError != null)
			{
				throw new IOException(string.Format
				(
					"Error reading bytes from: {1}{0}offset:{2}{0}count:{3}{0}message:{4}",
					Environment.NewLine,
					AssetRep.Url.AbsoluteString,
					offset,
					count,
					nsError.LocalizedDescription
				));
			}

			Position += bytesRead;
			return bytesRead;
		}

		/// <summary>
		/// Seek the stream to the specified offset from the specified origin.
		/// If an exception is thrown due to trying to seek outside the range of the source then the position is unchanged.
		/// see http://msdn.microsoft.com/en-us/library/system.io.stream.seek.aspx
		/// </summary>
		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
				case SeekOrigin.Begin:
					Position = offset;
					break;
				case SeekOrigin.Current:
					Position += offset;
					break;
				case SeekOrigin.End:
					Position = AssetRep.Size - offset;
					break;
			}

			// Don't check that this is a valid position because MS say that seek can go out of bounds...
			// "Seeking to any location beyond the length of the stream is supported."
			return Position;
		}
		/// <summary>
		/// Can't set the length - readonly
		/// </summary>
		public override void SetLength(long value) {  throw new NotImplementedException();  }

		/// <summary>
		/// Can't write - Readonly
		/// </summary>
		public override void Write(byte[] buffer, int offset, int count) {  throw new NotImplementedException();  }

		/// <summary>
		/// Gets a value indicating whether this instance can read - which it can provided it is not closed.
		/// </summary>
		public override bool CanRead { get {return AssetRep != null; } }

		/// <summary>
		/// Gets a value indicating whether this instance can seek - which it can provided it is not closed.
		/// </summary>
		public override bool CanSeek { get {return AssetRep != null; } }

		/// <summary>
		/// Gets a value indicating whether this instance can write - which it definately can't;
		/// </summary>
		public override bool CanWrite {	get{return false;}}

		/// <summary>
		/// Gets the length of the stream
		/// </summary>
		public override long Length
		{
			get{ return AssetRep.Size; }
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		public override long Position
		{
			get{ return m_Position; }
			set{ m_Position = value; }
		}
		protected long m_Position;

		protected override void Dispose(bool disposing){ /* do nothing */ }
	}
}

