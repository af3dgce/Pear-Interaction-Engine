﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pear.InteractionEngine.Converters
{
	/// <summary>
	/// Converts a vector 3 into another vector 3
	/// </summary>
	public class Vector3ToVector3 : MonoBehaviour, IPropertyConverter<Vector3, Vector3>
	{
		[Tooltip("Where should the X value be set")]
		public VectorFields SetXOn = VectorFields.X;

		[Tooltip("Multiplied on the X value when it's set")]
		public float XMultiplier = 1;

		[Tooltip("Where should the Y value be set")]
		public VectorFields SetYOn = VectorFields.X;

		[Tooltip("Multiplied on the Y value when it's set")]
		public float YMultiplier = 1;

		[Tooltip("Where should the Z value be set")]
		public VectorFields SetZOn = VectorFields.X;

		[Tooltip("Multiplied on the Z value when it's set")]
		public float ZMultiplier = 1;

		public Vector3 Convert(Vector3 convertFrom)
		{
			float x = 0;
			float y = 0;
			float z = 0;

			Dictionary<VectorFields, Action<float>> setActions = new Dictionary<VectorFields, Action<float>>()
			{
				{ VectorFields.X, val => x = val },
				{ VectorFields.Y, val => y = val },
				{ VectorFields.Z, val => z = val },
			};

			setActions[SetXOn](convertFrom.x * XMultiplier);
			setActions[SetYOn](convertFrom.y * YMultiplier);
			setActions[SetZOn](convertFrom.z * ZMultiplier);

			return new Vector3(x, y, z);
		}
	}
}
