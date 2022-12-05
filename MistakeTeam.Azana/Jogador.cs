namespace MistakeTeam.Azana
{
    public class Jogador
    {
        private ushort _vida = 567,
            _mana = 468,
            _ataque,
            _defesa,
            _agilidade,
            _carisma,
            _rvida,
            _rmana;
        private int[] _inventario = new int[10];

        public Jogador() { }

        public ushort Vida
        {
            get { return _vida; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 7000)
                    value = 7000;
                _vida = value;
            }
        }

        public ushort Mana
        {
            get { return _mana; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > 15000)
                    value = 15000;
                _mana = value;
            }
        }
    }
}
