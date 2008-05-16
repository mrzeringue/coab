using Classes;

namespace engine
{
    class ovr038
    {
		static Set Load8x8D_flags = new Set( 0x0001, new byte[] { 0x1F } );

        internal static void Load8x8D( byte arg_0, byte arg_2 )
        {
			if( Load8x8D_flags.MemberOf( arg_0 ) == true )
			{
                string text = "8x8d" + gbl.game_area.ToString();
				seg040.load_dax( ref gbl.symbol_8x8_set[arg_0], 13, 1, arg_2, text );

                if( gbl.symbol_8x8_set[arg_0] == null )
                {
                    seg051.Write( 0, "Unable to load ", gbl.known01_02 );
                    seg051.Write( 0, arg_2, gbl.known01_02 );

                    text = " from 8x8D" + gbl.game_area.ToString();

                    seg051.Write( 0, text, gbl.known01_02 );
                    seg051.WriteLn( gbl.known01_02 );

                    seg043.GetInputKey();

                    seg043.print_and_exit();
                }

				seg043.clear_keyboard();
			}
        }


        internal static void Put8x8Symbol( byte arg_0, bool arg_2, int symbol_id, int rowY, int colX )
        {
			byte symbol_set = 0; /*HACK to make compiler happy*/


            if( symbol_id >= 1 && symbol_id <= 0x2d )
            {
                symbol_set = 0;
            }
            else if( symbol_id >= 0x2E && symbol_id <= 0x73 )
            {
                symbol_set = 1;
            }
            else if( symbol_id >= 0x74 && symbol_id <= 0x0B9 )
            {
                symbol_set = 2;
            }
            else if( symbol_id >= 0x0BA && symbol_id <= 0x0FF )
            {
                symbol_set = 3;
            }
            else if( symbol_id >= 0x100 && symbol_id <= 0x127 )
            {
                symbol_set = 4;
            }
            else if( symbol_id == 0 || ( symbol_id >= 0x128 && symbol_id <= 0x7FFF ) )
            {
                throw new System.ApplicationException("Bad symbol number in Put8x8Symbol." + symbol_id);
            }

            if( gbl.symbol_8x8_set[symbol_set] != null )
            {
                symbol_id -= gbl.symbol_set_fix[symbol_set];

                if (arg_2)
                {
                    seg040.OverlayUnbounded(gbl.symbol_8x8_set[symbol_set], arg_0, symbol_id, rowY, colX);
                }
                else
                {
                    DaxBlock var_6 = gbl.symbol_8x8_set[symbol_set];

                    int ax = symbol_id * var_6.bpp;

					for( int i = 0; i < var_6.bpp; i++ )
					{
						gbl.dword_1C8F4.data[ i ] = var_6.data[ i + ax ];
					}
                    seg040.draw_picture( gbl.dword_1C8F4, rowY, colX, 0 );
                }
            }
        }
    }
}
