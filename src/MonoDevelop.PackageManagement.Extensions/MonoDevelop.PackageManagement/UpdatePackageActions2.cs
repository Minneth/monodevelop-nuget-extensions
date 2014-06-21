﻿// 
// UpdatePackageActions.cs
// 
// Author:
//   Matt Ward <ward.matt@gmail.com>
// 
// Copyright (C) 2013 Matthew Ward
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace ICSharpCode.PackageManagement
{
	public abstract class UpdatePackageActions2 : IUpdatePackageActions2
	{
		public bool UpdateDependencies { get; set; }
		public bool AllowPrereleaseVersions { get; set; }
		//public IPackageScriptRunner PackageScriptRunner { get; set; }

		public abstract IEnumerable<UpdatePackageAction2> CreateActions();

		protected UpdatePackageAction2 CreateDefaultUpdatePackageAction(IPackageManagementProject2 project)
		{
			UpdatePackageAction2 action = project.CreateUpdatePackageAction();
			SetUpdatePackageActionProperties(action);
			return action;
		}

		void SetUpdatePackageActionProperties(UpdatePackageAction2 action)
		{
			//action.PackageScriptRunner = PackageScriptRunner;
			action.UpdateDependencies = UpdateDependencies;
			action.UpdateIfPackageDoesNotExistInProject = false;
			action.AllowPrereleaseVersions = AllowPrereleaseVersions;
		}
	}
}