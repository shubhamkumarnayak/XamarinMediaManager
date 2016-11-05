﻿using System;
using CoreGraphics;
using Foundation;
using Plugin.MediaManager.Abstractions.Implementations;
using Plugin.MediaManager.Forms;
using Plugin.MediaManager.Forms.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace Plugin.MediaManager.Forms.iOS
{
    [Preserve(AllMembers = true)]
    public class VideoViewRenderer : ViewRenderer<VideoView, VideoSurface> 
    {
        private VideoSurface _videoSurface;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                _videoSurface = new VideoSurface();
                CrossMediaManager.Current.VideoPlayer.SetAspectMode(VideoAspectMode.AspectFill);
                SetNativeControl(_videoSurface);
                CrossMediaManager.Current.VideoPlayer.SetVideoSurface(_videoSurface);
            }
        }

        public override void Draw(CGRect rect)
        {
            _videoSurface.Frame = rect;
            base.Draw(rect);
        }
    }
}