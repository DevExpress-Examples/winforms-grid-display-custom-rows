using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GridCustomRows
{
    class PartContainer : INotifyPropertyChanged
    {
        int _id;
        int _part1;
        int _part2;
        int _part3;


        public PartContainer()
        {
            _id = 0;
            _part1 = 0;
            _part2 = 0;
            _part3 = 0;
        }
        public PartContainer(int id, int part1, int part2, int part3)
        {
            _id = id;
            _part1 = part1;
            _part2 = part2;
            _part3 = part3;
        }
        public int ID
        {
            get { return _id; }
            set
            {
                if (
                    _id == value)
                    return;
                _id = value;
                RisePropertyChanged("ID");
            }
        }
        public int Part1
        {
            get { return _part1; }
            set
            {
                if (
                    _part1 == value)
                    return;
                _part1 = value;
                RisePropertyChanged("Part1");
            }
        }
        public int Part2
        {
            get { return _part2; }
            set
            {
                if (
                    _part2 == value)
                    return;
                _part2 = value;
                RisePropertyChanged("Part2");
            }
        }
        public int Part3
        {
            get { return _part3; }
            set
            {
                if (
                    _part3 == value)
                    return;
                _part3 = value;
                RisePropertyChanged("Part3");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void RisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
    }

}
