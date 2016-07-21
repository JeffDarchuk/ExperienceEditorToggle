using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Common;
using Sitecore.Mvc.ExperienceEditor.Pipelines.RenderPageExtenders;

namespace ExperianceEditorToggle
{
	public class AddExperianceEditorToggle : RenderPageExtendersProcessor
	{
		public override void Process(RenderPageExtendersArgs args)
		{
			Assert.ArgumentNotNull((object)args, "args");
			if (args.IsRendered)
				return;
			this.Render(args.Writer);
			args.Disposables.Add((IDisposable)new GenericDisposable((Action)(() => args.Writer.Write("</form>"))));
		}

		protected override bool Render(TextWriter writer)
		{
			Assert.ArgumentNotNull((object)writer, "writer");
			writer.Write(@"<div id='scToggleUI'></div>
<form id='scPageExtendersForm' onsubmit='return false;' action=''>
<style>
#scCrossPiece 
	{
		display: none; 
	}
	#scPageExtendersForm { 
		display: none;
	}
	.sc-globalHeader-content
	{
		padding-left:40px;
	}
	#scToggleUI {
		position: fixed;
		top: 0;
		right: 0;
		z-index:9999;
		background: url('/sitecore/shell/Themes/Standard/images/hamburgermenu_default.png');
		width: 63px;
		height: 31px;
	}
</style>
<script>
	function toggle(){
			var sc = document.getElementById('scPageExtendersForm');
			var btn = document.getElementById('scToggleUI');
		
		if (sc.style.display === 'block'){
			document.cookie = 'scRibbon=0';
			sc.style.display = 'none';
			setCrossPiece('none');
			btn.style.right = 0;
		}else{
			document.cookie = 'scRibbon=1';
			sc.style.display = 'block';
			setCrossPiece('block');
			btn.style.right = '50%';
		}
	}
	function setCrossPiece(display){
		var cross = document.getElementById('scCrossPiece');
		if(cross){
			cross.style.display = display;
		}else{
			setTimeout(function(){setCrossPiece(display)}, 1);
		}
	}
	var btn = document.getElementById('scToggleUI')
	btn.onclick = toggle;
	var scRibbon = document.cookie.replace(/(?:(?:^|.*;\s*)scRibbon\s*\=\s*([^;]*).*$)|^.*$/, ""$""+""1"");
	if (scRibbon === '1'){
		toggle();
	}
</script>");

			
			return false;
		}
	}
}
