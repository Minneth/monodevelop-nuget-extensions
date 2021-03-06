﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Versioning;

namespace NuGet.PackageManagement.PowerShellCmdlets
{
	/// <summary>
	/// Represent the view of packages by Id and Versions
	/// </summary>
	public class PowerShellPackage
	{
		public string Id { get; set; }

		public IEnumerable<NuGetVersion> Versions {
			get {
				return GetVersions ().Result;
			}
		}

		async Task<IEnumerable<NuGetVersion>> GetVersions ()
		{
			var result = (await AsyncLazyVersions) ?? Enumerable.Empty<NuGetVersion> ();

			if (result.Any ()) {
				if (AllVersions) {
					return result;
				} else {
					// result has at least 1 element
					return result.Take (1);
				}
			}

			return null;
		}

		internal AsyncLazy<IEnumerable<NuGetVersion>> AsyncLazyVersions { get; set; }

		public SemanticVersion Version {
			get {
				var nVersion = Versions.FirstOrDefault ();

				if (nVersion != null) {
					SemanticVersion sVersion;
					SemanticVersion.TryParse (nVersion.ToNormalizedString (), out sVersion);
					return sVersion;
				}

				return null;
			}
		}

		public bool AllVersions { get; set; }

		public string LicenseUrl { get; set; }
	}
}