//using System;
//using Pokret.Areas.AdministracijaVozaca.Repositories;
//using Pokret.Areas.AdministracijaVozaca.Repositories.Interfaces;
//using Pokret.Areas.GlobalniSifarnici.Repositories;
//using Pokret.Areas.GlobalniSifarnici.Repositories.Interfaces;
//using Pokret.Areas.AdministracijaVozila.Repositories;
//using Pokret.Areas.AdministracijaVozila.Repositories.Interfaces;
//using Pokret.Models;
//using Pokret.Areas.AdministracijaNaloga.Repositories.Interfaces;
//using Pokret.Areas.AdministracijaNaloga.Repositories;
//using Pokret.Repositories.Interfaces;

//namespace Pokret.Repositories
//{
//    public class UnitOfWork : IDisposable
//    {
//        private readonly PokretEntities _context = new PokretEntities();

//        //private VrstaPakovanjaRepository _vrstaPakovanjaRepository;

//        #region
//        public IVoziloRepository VoziloRepository =>
//        _voziloRepository ?? (_voziloRepository = new VoziloRepository(_context));
//        private IVoziloRepository _voziloRepository;
//        #endregion

//        #region AdministracijaVozaca
//        private IFMVozacaRepository _fmVozacaRepository;
//        public IFMVozacaRepository FmVozacaRepository =>
//            _fmVozacaRepository ?? (_fmVozacaRepository = new FMVozacaRepository(_context));        

//        private IKategorijaVDRepository _kategorijaVdRepository;
//        public IKategorijaVDRepository KategorijaVDRepository =>
//            _kategorijaVdRepository ?? (_kategorijaVdRepository = new KategorijaVDRepository(_context));

//        private IVozacRepository _vozacRepository;
//        public IVozacRepository VozacRepository =>
//            _vozacRepository ?? (_vozacRepository = new VozacRepository(_context));

//        private IKategorijaVozacaRepository _kategorijaVozacRepository;
//        public IKategorijaVozacaRepository KategorijaVozacaRepository =>
//            _kategorijaVozacRepository ?? (_kategorijaVozacRepository = new KategorijaVozacaRepository(_context));
//        #endregion

//        #region AdministracijaVozila
//        private IIspravnostVozilaRepository _ispravnostVozilaRepository;
//        public IIspravnostVozilaRepository IspravnostVozilaRepository =>
//            _ispravnostVozilaRepository ?? (_ispravnostVozilaRepository = new IspravnostVozilaRepository(_context));

//        private ISmestajVozilaRepository _smestajVozilaRepository;
//        public ISmestajVozilaRepository SmestajVozilaRepository =>
//            _smestajVozilaRepository ?? (_smestajVozilaRepository = new SmestajVozilaRepository(_context));

//        private IStatusVozilaRepository _statusVozilaRepository;
//        public IStatusVozilaRepository StatusVozilaRepository =>
//            _statusVozilaRepository ?? (_statusVozilaRepository = new StatusVozilaRepository(_context));

       
//        public IVrstaVozilaRepository VrstaVozilaRepository =>
//            _vrstaVozilaRepository ?? (_vrstaVozilaRepository = new VrstaVozilaRepository(_context));
//        private IVrstaVozilaRepository _vrstaVozilaRepository;

//        #endregion

//        #region GlobalniSifarnici
//        private IJedinicaRepository _jedinicaRepository;
//        public IJedinicaRepository JedinicaRepository =>
//            _jedinicaRepository ?? (_jedinicaRepository = new JedinicaRepository(_context));

//        private IBorbenoOsiguranjeRepository _borbenoOsiguranjeRepository;
//        public IBorbenoOsiguranjeRepository BorbenoOsiguranjeRepository =>
//            _borbenoOsiguranjeRepository ?? (_borbenoOsiguranjeRepository = new BorbenoOsiguranjeRepository(_context));

//        private IJedinicaSemaRepository _jedinicaSemaRepository;
//        public IJedinicaSemaRepository JedinicaSemaRepository =>
//            _jedinicaSemaRepository ?? (_jedinicaSemaRepository = new JedinicaSemaRepository(_context));

//        private INacinRealizacijeRepository _nacinRealizacijeRepository;
//        public INacinRealizacijeRepository NacinRealizacijeRepository =>
//            _nacinRealizacijeRepository ?? (_nacinRealizacijeRepository = new NacinRealizacijeRepository(_context));

//        private ISifraObaveznoPoljeRepository _sifraObaveznoPoljeRepository;
//        public ISifraObaveznoPoljeRepository SifraObaveznoPoljeRepository =>
//            _sifraObaveznoPoljeRepository ?? (_sifraObaveznoPoljeRepository = new SifraObaveznoPoljeRepository(_context));

//        private IVrstaTeretaRepository _vrstaTeretaRepository;
//        public IVrstaTeretaRepository VrstaTeretaRepository =>
//            _vrstaTeretaRepository ?? (_vrstaTeretaRepository = new VrstaTeretaRepository(_context));

//        private IVrsteOpasneRobeRepository _vrsteOpasneRobeRepository;
//        public IVrsteOpasneRobeRepository VrsteOpasneRobeRepository =>
//            _vrsteOpasneRobeRepository ?? (_vrsteOpasneRobeRepository = new VrsteOpasneRobeRepository(_context));

//        private IVrstaPakovanjaRepository _vrstaPakovanjaRepository;
//        public IVrstaPakovanjaRepository VrstaPakovanjaRepository =>
//            _vrstaPakovanjaRepository ?? (_vrstaPakovanjaRepository = new VrstaPakovanjaRepository(_context));

//        private IVrstaZadatkaRepository _vrstaZadatkaRepository;
//        public IVrstaZadatkaRepository VrstaZadatkaRepository =>
//            _vrstaZadatkaRepository ?? (_vrstaZadatkaRepository = new VrstaZadatkaRepository(_context));


//        #endregion

//        #region AdministracijaNaloga

//        private INalogRepository _nalogRepository;
//        public INalogRepository NalogRepository =>
//            _nalogRepository ?? (_nalogRepository = new NalogRepository(_context));

//        private IUlogaRepository _UlogaRepository;
//        public IUlogaRepository UlogaRepository =>
//            _UlogaRepository ?? (_UlogaRepository = new UlogaRepository(_context));

//        private IUlogaNalogaRepository _UlogaNalogaRepository;
//        public IUlogaNalogaRepository UlogaNalogaRepository =>
//            _UlogaNalogaRepository ?? (_UlogaNalogaRepository = new UlogaNalogaRepository(_context));

//        #endregion
//        //public IVrstaPakovanjaRepository VrstaPakovanjaRepository =>
//        //    _vrstaPakovanjaRepository ?? (_vrstaPakovanjaRepository = new VrstaPakovanjaRepository(_context));

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        private bool _disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if(!_disposed)
//                if(disposing)
//                    _context.Dispose();
//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}