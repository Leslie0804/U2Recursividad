namespace _2._3Actividad
{
    public partial class Form1 : Form
    {
        // Pilas para almacenar los discos en cada torre (números del 1 al N)
        private Stack<int> torreA = new Stack<int>();
        private Stack<int> torreB = new Stack<int>();
        private Stack<int> torreC = new Stack<int>();

        private int totalDiscos = 3;
        private int pasoActual = 0;
        private int totalPasos = 0;
        private bool simulando = false;

        // Paleta de colores para los discos
        private readonly Color[] coloresDiscos = new Color[]
        {
            Color.Crimson,
            Color.DarkOrange,
            Color.Gold,
            Color.ForestGreen,
            Color.DodgerBlue,
            Color.RoyalBlue,
            Color.DarkViolet,
            Color.MediumVioletRed
        };

        public Form1()
        {
            InitializeComponent();
            InicializarTorres();
        }

        private void InicializarTorres()
        {
            totalDiscos = (int)numDiscos.Value;
            totalPasos = (int)Math.Pow(2, totalDiscos) - 1;
            pasoActual = 0;

            torreA.Clear();
            torreB.Clear();
            torreC.Clear();

            // Insertar discos en Torre A (del más grande al más pequeño)
            for (int i = totalDiscos; i >= 1; i--)
            {
                torreA.Push(i);
            }

            lblEstado.Text = $"Listo. Discos: {totalDiscos} | Movimientos mínimos: {totalPasos}";
            txtResultado.Clear();
            picTorres.Invalidate();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (simulando) return;

            simulando = true;
            btnIniciar.Enabled = false;
            numDiscos.Enabled = false;
            InicializarTorres();

            txtResultado.AppendText($"--- Inicio de Simulación ({totalDiscos} discos) ---" + Environment.NewLine);

            // Iniciar recursividad visual
            await HanoiVisualAsync(totalDiscos, 'A', 'B', 'C');

            if (simulando)
            {
                lblEstado.Text = $"¡Simulación completada con éxito en {pasoActual} movimientos!";
            }

            simulando = false;
            btnIniciar.Enabled = true;
            numDiscos.Enabled = true;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            simulando = false;
            btnIniciar.Enabled = true;
            numDiscos.Enabled = true;
            InicializarTorres();
        }

        private void numDiscos_ValueChanged(object sender, EventArgs e)
        {
            if (!simulando)
            {
                InicializarTorres();
            }
        }

        // ALGORITMO RECURSIVO VISUAL 
        private async Task HanoiVisualAsync(int n, char origen, char auxiliar, char destino)
        {
            if (!simulando) return;

            if (n == 1)
            {
                await MoverDiscoVisual(origen, destino);
                return;
            }

            await HanoiVisualAsync(n - 1, origen, destino, auxiliar);
            if (!simulando) return;

            await MoverDiscoVisual(origen, destino);
            if (!simulando) return;

            await HanoiVisualAsync(n - 1, auxiliar, origen, destino);
        }

        private async Task MoverDiscoVisual(char origen, char destino)
        {
            if (!simulando) return;

            Stack<int> pilaOrigen = ObtenerPila(origen);
            Stack<int> pilaDestino = ObtenerPila(destino);

            if (pilaOrigen.Count > 0)
            {
                int disco = pilaOrigen.Pop();
                pilaDestino.Push(disco);

                pasoActual++;
                string textoPaso = $"Paso {pasoActual}/{totalPasos}: Mover disco {disco} de {origen} a {destino}";
                lblEstado.Text = textoPaso;
                txtResultado.AppendText(textoPaso + Environment.NewLine);

                // Redibujar gráfico
                picTorres.Invalidate();
                picTorres.Update();

                // Retardo según la barra de velocidad
                int retardo = 1050 - trackVelocidad.Value;
                await Task.Delay(retardo);
            }
        }

        private Stack<int> ObtenerPila(char torre)
        {
            return torre switch
            {
                'A' => torreA,
                'B' => torreB,
                'C' => torreC,
                _ => torreA
            };
        }

        //  DIBUJADO DE TORRES Y DISCOS 
        private void picTorres_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int ancho = picTorres.ClientSize.Width;
            int alto = picTorres.ClientSize.Height;

            int yBase = alto - 45;
            int altoBase = 15;

            // 1. Dibujar base
            using (SolidBrush brochaBase = new SolidBrush(Color.SaddleBrown))
            {
                g.FillRectangle(brochaBase, 20, yBase, ancho - 40, altoBase);
            }

            // Coordenadas X para los 3 postes
            int xA = ancho / 4;
            int xB = ancho / 2;
            int xC = (ancho * 3) / 4;

            int anchoPoste = 10;
            int altoPoste = 190;
            int yPoste = yBase - altoPoste;

            // 2. Dibujar postes
            using (SolidBrush brochaPoste = new SolidBrush(Color.FromArgb(160, 82, 45)))
            {
                g.FillRectangle(brochaPoste, xA - (anchoPoste / 2), yPoste, anchoPoste, altoPoste);
                g.FillRectangle(brochaPoste, xB - (anchoPoste / 2), yPoste, anchoPoste, altoPoste);
                g.FillRectangle(brochaPoste, xC - (anchoPoste / 2), yPoste, anchoPoste, altoPoste);
            }

            // Nombres de las torres
            using (Font fuente = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (SolidBrush brochaTexto = new SolidBrush(Color.Black))
            {
                StringFormat formato = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("Torre A", fuente, brochaTexto, xA, yBase + 18, formato);
                g.DrawString("Torre B", fuente, brochaTexto, xB, yBase + 18, formato);
                g.DrawString("Torre C", fuente, brochaTexto, xC, yBase + 18, formato);
            }

            // 3. Dibujar discos de cada torre
            DibujarDiscosTorre(g, torreA, xA, yBase);
            DibujarDiscosTorre(g, torreB, xB, yBase);
            DibujarDiscosTorre(g, torreC, xC, yBase);
        }

        private void DibujarDiscosTorre(Graphics g, Stack<int> torre, int centroX, int yBase)
        {
            int altoDisco = 18;
            int[] discos = torre.ToArray(); // El índice 0 es el tope (disco superior)
            Array.Reverse(discos);          // Invertir para dibujar desde la base hacia arriba

            for (int nivel = 0; nivel < discos.Length; nivel++)
            {
                int numDisco = discos[nivel];
                // Calcular ancho proporcional al número de disco
                int anchoDisco = 35 + (numDisco * (120 / Math.Max(totalDiscos, 1)));
                int xDisco = centroX - (anchoDisco / 2);
                int yDisco = yBase - ((nivel + 1) * (altoDisco + 2));

                Color color = coloresDiscos[(numDisco - 1) % coloresDiscos.Length];

                using (SolidBrush brochaDisco = new SolidBrush(color))
                using (Pen borde = new Pen(Color.FromArgb(50, 0, 0, 0), 1.5f))
                {
                    g.FillRectangle(brochaDisco, xDisco, yDisco, anchoDisco, altoDisco);
                    g.DrawRectangle(borde, xDisco, yDisco, anchoDisco, altoDisco);
                }

                // Número del disco en el centro
                using (Font fuente = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (SolidBrush brochaNum = new SolidBrush(Color.White))
                {
                    StringFormat formato = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(numDisco.ToString(), fuente, brochaNum, new RectangleF(xDisco, yDisco, anchoDisco, altoDisco), formato);
                }
            }
        }

        // MEDICIÓN Y ANÁLISIS DE PROFUNDIDAD 
        private long totalMovimientosMedidos = 0;
        private int profundidadMaximaAlcanzada = 0;

        private async void btnAnalizar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            txtResultado.AppendText("Analizando comportamiento según la profundidad de llamada..." + Environment.NewLine);
            txtResultado.AppendText("Espere un momento..." + Environment.NewLine + Environment.NewLine);

            // Deshabilitar botón durante la prueba
            btnAnalizar.Enabled = false;

            // Ejecutar en segundo plano para no congelar la interfaz
            string reporte = await Task.Run(() => GenerarReporteProfundidades());

            txtResultado.Text = reporte;
            btnAnalizar.Enabled = true;
        }

        private string GenerarReporteProfundidades()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("======================================================================");
            sb.AppendLine(" REPORTE: COMPORTAMIENTO SEGÚN LA PROFUNDIDAD DE LLAMADA (TORRES DE HANOI)");
            sb.AppendLine("======================================================================");
            sb.AppendLine(string.Format("{0,-12} | {1,-18} | {2,-16} | {3,-15} | {4,-12}",
                "Profundidad", "Movimientos", "Tiempo (ms)", "Memoria Usada", "Prof. Pila"));
            sb.AppendLine("------------------------------------------------------------------------------------------");

            // Evaluamos diferentes profundidades de llamada (n)
            int[] casosProfundidad = new int[] { 3, 5, 8, 12, 16, 20, 24 };

            foreach (int n in casosProfundidad)
            {
                totalMovimientosMedidos = 0;
                profundidadMaximaAlcanzada = 0;

                // Limpiar recolector de basura para medición más precisa de memoria
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                long memoriaInicial = GC.GetTotalMemory(true);

                // Medir tiempo de alta precisión con Stopwatch
                var cronometro = System.Diagnostics.Stopwatch.StartNew();

                // Ejecución recursiva midiendo la profundidad
                EjecutarHanoiConMedicion(n, 1, 'A', 'B', 'C');

                cronometro.Stop();
                long memoriaFinal = GC.GetTotalMemory(false);
                long memoriaUsadaBytes = Math.Max(0, memoriaFinal - memoriaInicial);

                double tiempoMs = cronometro.Elapsed.TotalMilliseconds;
                string memoriaTexto = memoriaUsadaBytes < 1024 ? $"{memoriaUsadaBytes} B" : $"{memoriaUsadaBytes / 1024.0:F2} KB";

                sb.AppendLine(string.Format("{0,-12} | {1,-18:N0} | {2,-16:F4} | {3,-15} | {4,-12}",
                    $"n = {n}",
                    totalMovimientosMedidos,
                    tiempoMs,
                    memoriaTexto,
                    $"{profundidadMaximaAlcanzada} niveles"));
            }

            sb.AppendLine("======================================================================");
            sb.AppendLine(" CONCLUSIONES DEL ANÁLISIS:");
            sb.AppendLine(" 1. Memoria de Pila (Call Stack): Crece de forma LINEAL O(n), alcanzando exactamente 'n' niveles.");
            sb.AppendLine(" 2. Tiempo y Movimientos: Crecen de forma EXPONENCIAL O(2^n). Cada incremento en 'n'");
            sb.AppendLine("    duplica el total de llamadas y el tiempo de cómputo.");
            sb.AppendLine("======================================================================");

            return sb.ToString();
        }

        // Función recursiva optimizada para medición que rastrea la profundidad de llamadas
        private void EjecutarHanoiConMedicion(int n, int profundidadActual, char origen, char auxiliar, char destino)
        {
            totalMovimientosMedidos++;

            if (profundidadActual > profundidadMaximaAlcanzada)
            {
                profundidadMaximaAlcanzada = profundidadActual;
            }

            // CASO BASE
            if (n == 1)
            {
                return;
            }

            // CASOS RECURSIVOS (aumentan la profundidad en 1 en cada nivel)
            EjecutarHanoiConMedicion(n - 1, profundidadActual + 1, origen, destino, auxiliar);
            EjecutarHanoiConMedicion(n - 1, profundidadActual + 1, auxiliar, origen, destino);
        }
    }
}