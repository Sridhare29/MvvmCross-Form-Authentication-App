using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AuthenticationApp.Model;

namespace Authmvvmcross.Core.ViewModels
{
    public class CourseViewModel
    {
        public ObservableCollection<CourseInfo> courses { get; set; }

        public CourseViewModel()
        {
            courses = new ObservableCollection<CourseInfo>();
            courses.Add(new CourseInfo { Name = "Java", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTElwLMovyBMM2dMspVJq5qFR-WChGZeblP-hwM8HE&s" });
            courses.Add(new CourseInfo { Name = "Dot Net", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/2048px-Microsoft_.NET_logo.svg.png" });
            courses.Add(new CourseInfo { Name = "Angular", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpmJeWNFTh-yppE0fGSNrHpkvi0SRswuLV6ZNGez0ZZQ&s" });
            courses.Add(new CourseInfo { Name = "React Native", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTl7-ZavkyPWWFO3dxJ4eSLGHLgv_4FaB75mXluYqQ&s" });
            courses.Add(new CourseInfo { Name = "Xamarin", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHzsFhYZie4cAtmilsv9ownt8e5QooVdJhcg&usqp=CAU" });
        }
    }
}
