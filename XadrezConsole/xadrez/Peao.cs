using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValor(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                // jogada especial En Passant
                if (posicao.linha == 3)
                {
                    Posicao esqueda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esqueda) && existeInimigo(esqueda) && tab.peca(esqueda) == partida.VuneravelEnPassant)
                        mat[esqueda.linha - 1, esqueda.coluna] = true;

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.VuneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.definirValor(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValor(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                // jogada especial En Passant
                if (posicao.linha == 4)
                {
                    Posicao esqueda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esqueda) && existeInimigo(esqueda) && tab.peca(esqueda) == partida.VuneravelEnPassant)
                        mat[esqueda.linha + 1, esqueda.coluna] = true;

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.VuneravelEnPassant)
                        mat[direita.linha + 1, direita.coluna] = true;

                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
