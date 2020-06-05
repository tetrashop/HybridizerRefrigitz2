using System.Diagnostics;
using System.Collections.Generic;
using System;




public static class GlobalMembersUcioption
{
	
	  


	

	
    
	public const int MAX_MOVES = 256;
	public const int MAX_PLY = 128;

	public static readonly Piece[] Pieces = {Piece.W_PAWN, Piece.W_KNIGHT, Piece.W_BISHOP, Piece.W_ROOK, Piece.W_QUEEN, Piece.W_KING, Piece.B_PAWN, Piece.B_KNIGHT, Piece.B_BISHOP, Piece.B_ROOK, Piece.B_QUEEN, Piece.B_KING};



//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<MoveType T>
public static Move make<MoveType T>(Square from, Square to)
{
	return make(from, to, PieceType.KNIGHT);
}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: inline Move make(Square from, Square to, PieceType pt = KNIGHT)
	public static Move make<MoveType T>(Square from, Square to, PieceType pt)
	{
	  return Move(T + ((pt - PieceType.KNIGHT) << 12) + (from << 6) + to);
	}

    	public static bool is_ok(Move m)
        {
          return GlobalMembersBenchmark.from_sq(m) != GlobalMembersBenchmark.to_sq(m); 
        }


     

    public const ulong DarkSquares = 0xAA55AA55AA55AA55UL;

	public const ulong FileABB = 0x0101010101010101UL;
	public static ulong FileBBB = FileABB << 1;
	public static ulong FileCBB = FileABB << 2;
	public static ulong FileDBB = FileABB << 3;
	public static ulong FileEBB = FileABB << 4;
	public static ulong FileFBB = FileABB << 5;
	public static ulong FileGBB = FileABB << 6;
	public static ulong FileHBB = FileABB << 7;

	public const ulong Rank1BB = 0xFF;
	public static ulong Rank2BB = Rank1BB << (8 * 1);
	public static ulong Rank3BB = Rank1BB << (8 * 2);
	public static ulong Rank4BB = Rank1BB << (8 * 3);
	public static ulong Rank5BB = Rank1BB << (8 * 4);
	public static ulong Rank6BB = Rank1BB << (8 * 5);
	public static ulong Rank7BB = Rank1BB << (8 * 6);
	public static ulong Rank8BB = Rank1BB << (8 * 7);
	



  public static SortedDictionary<string, Option, CaseInsensitiveLess> Options = new SortedDictionary<string, Option, CaseInsensitiveLess>(); 
    

}

/// A move needs 16 bits to be stored
///
/// bit  0- 5: destination square (from 0 to 63)
/// bit  6-11: origin square (from 0 to 63)
/// bit 12-13: promotion piece type - 2 (from KNIGHT-2 to QUEEN-2)
/// bit 14-15: special move flag: promotion (1), en passant (2), castling (3)
/// NOTE: EN-PASSANT bit is set only when a pawn can be captured
///
/// Special cases are MOVE_NONE and MOVE_NULL. We can sneak these in because in
/// any normal move destination square is always different from origin square
/// while MOVE_NONE and MOVE_NULL have the same origin and destination square.



public enum MoveType
{
  NORMAL,
  PROMOTION = 1 << 14,
  ENPASSANT = 2 << 14,
  CASTLING = 3 << 14
}




public enum CastlingRight
{
  NO_CASTLING,
  WHITE_OO,
  WHITE_OOO = WHITE_OO << 1,
  BLACK_OO = WHITE_OO << 2,
  BLACK_OOO = WHITE_OO << 3,
  ANY_CASTLING = WHITE_OO | WHITE_OOO | BLACK_OO | BLACK_OOO,
  CASTLING_RIGHT_NB = 16
}

public enum Bound
{
  BOUND_NONE,
  BOUND_UPPER,
  BOUND_LOWER,
  BOUND_EXACT = BOUND_UPPER | BOUND_LOWER
}

public enum Value : int
{
  VALUE_ZERO = 0,
  VALUE_DRAW = 0,
  VALUE_KNOWN_WIN = 10000,
  VALUE_MATE = 32000,
  VALUE_INFINITE = 32001,
  VALUE_NONE = 32002,

  VALUE_MATE_IN_MAX_PLY = VALUE_MATE - 2 * MAX_PLY,
  VALUE_MATED_IN_MAX_PLY = -VALUE_MATE + 2 * MAX_PLY,

  PawnValueMg = 188,
  PawnValueEg = 248,
  KnightValueMg = 753,
  KnightValueEg = 832,
  BishopValueMg = 826,
  BishopValueEg = 897,
  RookValueMg = 1285,
  RookValueEg = 1371,
  QueenValueMg = 2513,
  QueenValueEg = 2650,

  MidgameLimit = 15258,
  EndgameLimit = 3915
}

public enum PieceType
{
  NO_PIECE_TYPE,
  PAWN,
  KNIGHT,
  BISHOP,
  ROOK,
  QUEEN,
  KING,
  ALL_PIECES = 0,
  PIECE_TYPE_NB = 8
}

public enum Piece
{
  NO_PIECE,
  W_PAWN = 1,
  W_KNIGHT,
  W_BISHOP,
  W_ROOK,
  W_QUEEN,
  W_KING,
  B_PAWN = 9,
  B_KNIGHT,
  B_BISHOP,
  B_ROOK,
  B_QUEEN,
  B_KING,
  PIECE_NB = 16
}

public enum Depth
{

  ONE_PLY = 1,

  DEPTH_ZERO = 0 * ONE_PLY,
  DEPTH_QS_CHECKS = 0 * ONE_PLY,
  DEPTH_QS_NO_CHECKS = -1 * ONE_PLY,
  DEPTH_QS_RECAPTURES = -5 * ONE_PLY,

  DEPTH_NONE = -6 * ONE_PLY,
  DEPTH_MAX = MAX_PLY * ONE_PLY
}

//C++ TO C# CONVERTER TODO TASK: There is no equivalent in C# to 'static_assert':


public enum File : int
{
  FILE_A,
  FILE_B,
  FILE_C,
  FILE_D,
  FILE_E,
  FILE_F,
  FILE_G,
  FILE_H,
  FILE_NB
}

public enum Rank : int
{
  RANK_1,
  RANK_2,
  RANK_3,
  RANK_4,
  RANK_5,
  RANK_6,
  RANK_7,
  RANK_8,
  RANK_NB
}


/// Score enum stores a middlegame and an endgame value in a single integer
/// (enum). The least significant 16 bits are used to store the endgame value
/// and the upper 16 bits are used to store the middlegame value. Take some
/// care to avoid left-shifting a signed int to avoid undefined behavior.
public enum Score : int
{
	SCORE_ZERO
}




public class ExtMove
{
  public Move move;
  public Value value;
  public static implicit operator Move(ExtMove ImpliedObject)
  {
	  return ImpliedObject.move;
  }
//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: void operator =(Move m)
  
  public void CopyFrom(Move m)
  {
	  move = m;
  }*/
}

public class MoveList <GenType T>
{

  public MoveList(Position pos)
  {
	  this.last = generate<T>(pos, moveList);
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ExtMove* begin() const
  public ExtMove begin()
  {
	  return moveList;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const ExtMove* end() const
  public ExtMove end()
  {
	  return last;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint size() const
  public uint size()
  {
	  return last - moveList;
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool contains(Move move) const
  public bool contains(Move move)
  {
	foreach (var m in * this)
	{
		if (m == move)
		{
			return true;
		}
	}
	return false;
  }

private ExtMove[] moveList = Arrays.InitializeWithDefaultInstances<ExtMove>(MAX_MOVES);
  private ExtMove last;
}









/// StateInfo struct stores information needed to restore a Position object to
/// its previous state when we retract a move. Whenever a move is made on the
/// board (by calling Position::do_move), a StateInfo object must be passed.

public class StateInfo
{

  // Copied when making a move
  public ulong pawnKey;
  public ulong materialKey;
  public Value[] nonPawnMaterial = new Value[(int)Color.COLOR_NB];
  public int castlingRights;
  public int rule50;
  public int pliesFromNull;
  public Score psq;
  public Square epSquare;

  // Not copied when making a move (will be recomputed anyhow)
  public ulong key;
  public ulong checkersBB;
  public Piece capturedPiece;
  public StateInfo previous;
  public ulong[] blockersForKing = new ulong[(int)Color.COLOR_NB];
  public ulong[] pinnersForKing = new ulong[(int)Color.COLOR_NB];
  public ulong[] checkSquares = new ulong[(int)PieceType.PIECE_TYPE_NB];
}

// In a std::deque references to elements are unaffected upon resizing


/// Position class stores information regarding the board representation as
/// pieces, side to move, hash keys, castling info, etc. Important methods are
/// do_move() and undo_move(), used by the search to update node info when
/// traversing the search tree.
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:

public class Stats <T, bool CM = false>
{

  public Value Max = new Value(1 << 28);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: const T* operator [](Piece pc) const
  public T this[Piece pc]
  {
	  get
	  {
		  return table[(int)pc];
	  }
  }
  public T this[Piece pc]
  {
	  get
	  {
		  return table[(int)pc];
	  }
  }
  public void clear()
  {
	  std.memset(table, 0, sizeof(T));
  }
  public void update(Piece pc, Square to, Move m)
  {
	  table[(int)pc, (int)to] = m;
  }
  public void update(Piece pc, Square to, Value v)
  {

	if (Math.Abs((int)v) >= 324)
		return;

	table[(int)pc, (int)to] -= table[(int)pc, (int)to] * Math.Abs((int)v) / (CM ? 936 : 324);
	table[(int)pc, (int)to] += (int)v * 32;
  }

  private T[,] table = new T[(int)Piece.PIECE_NB, (int)Square.SQUARE_NB];
}


public class FromToStats
{

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Value get(Color c, Move m) const
  public Value get(Color c, Move m)
  {
	  return table[(int)c, GlobalMembersBenchmark.from_sq(m), (int)GlobalMembersBenchmark.to_sq(m)];
  }
  public void clear()
  {
	  std.memset(table, 0, sizeof(Value));
  }
  public void update(Color c, Move m, Value v)
  {

	if (Math.Abs((int)v) >= 324)
		return;

	Square from = GlobalMembersBenchmark.from_sq(m);
	Square to = GlobalMembersBenchmark.to_sq(m);

	table[(int)c, from, (int)to] -= table[(int)c, from, (int)to] * Math.Abs((int)v) / 324;
	table[(int)c, from, (int)to] += (int)v * 32;
  }

  private Value[,,] table = new Value[(int)Color.COLOR_NB, Square.SQUARE_NB, (int)Square.SQUARE_NB];
}


/// MovePicker class is used to pick one pseudo legal move at a time from the
/// current position. The most important method is next_move(), which returns a
/// new pseudo legal move each time it is called, until there are no moves left,
/// when MOVE_NONE is returned. In order to improve the efficiency of the alpha
/// beta algorithm, MovePicker attempts to return the moves which are most likely
/// to get a cut-off first.


namespace Search
{


/// RootMove struct is used for moves at the root of the tree. For each root move
/// we store a score and a PV (really a refutation in the case of moves which
/// fail low). Score is normally set at -VALUE_INFINITE for all non-pv moves.

public class RootMove
{

  public Value score = -Value.VALUE_INFINITE;
  public Value previousScore = -Value.VALUE_INFINITE;
  public List<Move> pv = new List<Move>();
}



/// LimitsType struct stores information sent by GUI about available time to
/// search the current move, maximum depth/time, if we are in analysis mode or
/// if we have to ponder while it's our opponent's turn to move.

public class LimitsType
{

  public LimitsType() // Init explicitly due to broken value-initialization of non POD in MSVC
  {
	nodes = time[(int)Color.WHITE] = time[(int)Color.BLACK] = inc[(int)Color.WHITE] = inc[(int)Color.BLACK] = npmsec = movestogo = depth = movetime = mate = infinite = ponder = 0;
  }

  public List<Move> searchmoves = new List<Move>();
  public int[] time = new int[(int)Color.COLOR_NB];
  public int[] inc = new int[(int)Color.COLOR_NB];
  public int npmsec;
  public int movestogo;
  public int depth;
  public int movetime;
  public int mate;
  public int infinite;
  public int ponder;
  public long nodes;
  public std.chrono.milliseconds.rep startTime = new std.chrono.milliseconds.rep();
}


public class SignalsType
{
  public std.atomic_bool stop = new std.atomic_bool();
  public std.atomic_bool stopOnPonderhit = new std.atomic_bool();
}

} // namespace Search



 



/// TTEntry struct is the 10 bytes transposition table entry, defined as below:
///
/// key        16 bit
/// move       16 bit
/// value      16 bit
/// eval value 16 bit
/// generation  6 bit
/// bound type  2 bit
/// depth       8 bit

public class TTEntry <bool Root = true>
{
 

  private ushort key16;
  private ushort move16;
  private short value16;
  private short eval16;
  private byte genBound8;
  private sbyte depth8;
}

namespace UCI
{


/// Our options container is actually a std::map

/// Option class implements an option as defined by UCI protocol
public class Option
{

  private delegate void OnChange(Option NamelessParameter);


  public Option() : this(null)
  {
  }
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: Option(OnChange f = null) : type("button"), min(0), max(0), on_change(f)
  public Option(OnChange f)
  {
	  this.type = "button";
	  this.min = 0;
	  this.max = 0;
	  this.on_change = f;
  }
  public Option(bool v) : this(v, null)
  {
  }
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: Option(bool v, OnChange f = null) : type("check"), min(0), max(0), on_change(f)
  public Option(bool v, OnChange f)
  {
	  this.type = "check";
	  this.min = 0;
	  this.max = 0;
	  this.on_change = f;
	  defaultValue = currentValue = (v ? "true" : "false");
  }

  /// Option class constructors and conversion operators

  public Option(string v) : this(v, null)
  {
  }
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: Option(const sbyte* v, OnChange f = null) : type("string"), min(0), max(0), on_change(f)
  public Option(string v, OnChange f)
  {
	  this.type = "string";
	  this.min = 0;
	  this.max = 0;
	  this.on_change = f;
	  defaultValue = currentValue = ((char)v).ToString();
  }
  public Option(int v, int minv, int maxv) : this(v, minv, maxv, null)
  {
  }
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: Option(int v, int minv, int maxv, OnChange f = null) : type("spin"), min(minv), max(maxv), on_change(f)
  public Option(int v, int minv, int maxv, OnChange f)
  {
	  this.type = "spin";
	  this.min = minv;
	  this.max = maxv;
	  this.on_change = f;
	  defaultValue = currentValue = std.to_string(v);
  }


  /// operator=() updates currentValue and triggers on_change() action. It's up to
  /// the GUI to check for option's limits, but we could receive the new value from
  /// the user by console window, so let's check the bounds anyway.

//C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
//ORIGINAL LINE: Option& operator =(const string& v)
  public Option CopyFrom(string v)
  {

	Debug.Assert(!string.IsNullOrEmpty(type));

	if ((type != "button" && string.IsNullOrEmpty(v)) || (type == "check" && v != "true" && v != "false") || (type == "spin" && (stoi(v) < min || stoi(v) > max)))
	{
		return this;
	}

	if (type != "button")
	{
		currentValue = v;
	}

	if (on_change)
	{
		on_change(this);
	}

	return this;
  }

  /// operator<<() inits options and assigns idx in the correct printing order

//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
  private uint operator << _insert_order = 0;
  public static void operator << (Option ImpliedObject, Option o)
  {

//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:


	*ImpliedObject = o;
	ImpliedObject.idx = operator << _insert_order++;
  }*/
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: operator int() const
  public static implicit operator int(Option ImpliedObject)
  {
	Debug.Assert(ImpliedObject.type == "check" || ImpliedObject.type == "spin");
	return (ImpliedObject.type == "spin" ? stoi(ImpliedObject.currentValue) : ImpliedObject.currentValue == "true");
  }
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: operator string() const
  public static implicit operator string(Option ImpliedObject)
  {
	Debug.Assert(ImpliedObject.type == "string");
	return ImpliedObject.currentValue;
  }
  public static bool BestMove;
//C++ TO C# CONVERTER TODO TASK: C# has no concept of a 'friend' function:

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:


  private string defaultValue;
  private string currentValue;
  private string type;
  private int min;
  private int max;
  private uint idx;
  private OnChange on_change;
}

} // namespace UCI

