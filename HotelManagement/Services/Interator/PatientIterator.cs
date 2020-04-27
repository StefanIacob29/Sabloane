using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services.Interator
{
    public class PatientIterator : IPatientterator
    {
        private List<Patient>  _patients;
        private int _current = 0;
        private int _step = 1;
        public bool IsDone
        {
            get { return _current >= _patients.Count; }
        }

        public int getCurrentIndex()
        {
            return _current;
        }
        public PatientIterator(List<Patient> Patients )
        {
            this._patients = Patients;
        }
        public Patient CurrentPatient
        {
            get { return _patients[_current] as Patient; }
        }

        public Patient First()
        {
            _current = 0;
            return _patients[_current] as Patient;
        }

        public Patient Next()
        {
            _current += _step;
            if (!IsDone)
                return _patients[_current] as Patient;
            else
                return null;
        }
    }
}
