﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
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
using System.Windows.Controls;
using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;

namespace CSharpBinding.Completion
{
	class EntityCompletionData : CompletionData, IEntityCompletionData
	{
		readonly IEntity entity;
		
		public IEntity Entity {
			get { return entity; }
		}
		
		public EntityCompletionData(IEntity entity) : base(entity.Name)
		{
			this.entity = entity;
			this.Image = ClassBrowserIconService.GetIcon(entity);
			// don't set this.Description -- we use CreateFancyDescription() instead,
			// and accessing entity.Documentation in the constructor is too slow
		}
		
		protected override object CreateFancyDescription()
		{
			return new FlowDocumentScrollViewer {
				Document = XmlDocFormatter.CreateTooltip(entity, false),
				VerticalScrollBarVisibility = ScrollBarVisibility.Auto
			};
		}
	}
}
