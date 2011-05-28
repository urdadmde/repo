%%
%% This is file `sacj.cls',
%% generated with the docstrip utility.
%%
%% The original source files were:
%%
%% sacj.dtx  (with options: `class')
%% 
%% This is a generated file.
%% 
%% Copyright (C) 2005 by Marco Slaviero
%% 
%% --------------------------------------------------------------
%% 
%% It may be distributed and/or modified under the
%% conditions of the LaTeX Project Public License, either version 1.3
%% of this license or (at your option) any later version.
%% The latest version of this license is in
%%    http://www.latex-project.org/lppl.txt
%% and version 1.3 or later is part of all distributions of LaTeX
%% version 2003/12/01 or later.
%% 
%% This file has the LPPL maintenance status "maintained".
%% 

\NeedsTeXFormat{LaTeX2e}[1999/12/01]
\ProvidesClass{sacj}
  [2005/05/30 v1.0 LaTeX class file for the South African Computer Journal ]

\def\@email{}
\newcommand{\@articletype}{Research Article}
\newcounter{@authorfootnote}
\setcounter{@authorfootnote}{1}
\def\@authoronly{}
\newcommand{\email}{\@email}
\newcommand{\SACJvolume}{Submission}
\newcommand{\SACJyear}{\number\year}
\newcommand{\SACJauthor}[3][default]{%
  \expandafter\ifx\csname @SACJnote#1\endcsname\relax %Test whether @SACJnote#1 /does not/ exist
    %Check if more than nine addresses exist
    \ifnum\the@authorfootnote>9\relax
      \ClassError{sacj}{More than nine addresses detected, cannot continue.}{Please reduce the number of \SACJaddress\space invocations.}
    \fi
    %Now check if multiple addresses are in place
    \def\@testforx{default}
    \def\@firstarg{#1}
    \ifx\@firstarg\@testforx %Test for optional argument
      \edef\@@note{} %Optional argument not present
    \else
      \edef\@@note{\fnsymbol{@authorfootnote}} %Optional argument present
    \fi
    \expandafter\edef\csname @SACJnote#1\endcsname{\@@note}%
    \stepcounter{@authorfootnote}
  \fi
  \ifx\@author\@empty\else
    \g@addto@macro\@author{, }%Adds in trailing comma
    \g@addto@macro\@authoronly{, }%Adds in trailing comma, for the author list which goes in the TOC
  \fi
  \def\@thirdarg{#3}
  \ifx\@thirdarg\@empty\else
    \ifx\@email\@empty\else
      \g@addto@macro\@email{, }%Adds in trailing comma
    \fi
    \g@addto@macro\@email{#2 \texttt{#3}}%
  \fi
  \g@addto@macro\@author{#2\textsuperscript{\csname @SACJnote#1\endcsname}}%
  \g@addto@macro\@authoronly{#2}%
}
\newcommand{\@addresses}{}
\author{}
\title{}
\newcommand{\SACJtitle}[1]{\def\@title{#1}}
\newcommand{\SACJaddress}[2][default]{%
  %\edef\@note{\csname @SACJnote#1\endcsname}%
  \expandafter\ifx\csname @SACJnote#1\endcsname\relax %Test whether @SACJnote#1 /does not/ exist
    \PackageWarning{sacj}{Address (#2) is not linked to any authors. I refuse to include it.}%
  \else%
    \g@addto@macro\@addresses{\textsuperscript{\csname @SACJnote#1\endcsname}#2\par}%
  \fi%
  %Mark:\@note Address:#2%
}

\newcounter{@volumenumber}
\setcounter{@volumenumber}{34}
\def\@received{}
\newcommand\SACJreceived[1]{\renewcommand{\@received}{\noindent\textbf{Received:}\hspace{51pt}#1\par}}
\def\@commentssent{}
\newcommand\SACJcommentssent[1]{\renewcommand{\@commentssent}{\noindent\textbf{Comments returned:} #1\par}}
\def\@corrected{}
\newcommand\SACJcorrected[1]{\renewcommand{\@corrected}{\noindent\textbf{Corrected copy:}\hspace{24pt}#1\par}}

\DeclareOption{final}{\renewcommand{\SACJvolume}{No. \arabic{@volumenumber}.}}
\DeclareOption{communication}{\renewcommand{\@articletype}{Communication}}
\DeclareOption{editorial}{\renewcommand{\@articletype}{Editorial}}
\DeclareOption{erratum}{\renewcommand{\@articletype}{Erratum}}
\newif\ifincludenumbers
\includenumbersfalse
\DeclareOption{includenumbers}{\includenumberstrue}
\DeclareOption*{\typeout{Unknown option `\CurrentOption'}}
\ProcessOptions\relax
\LoadClass[twocolumn,twoside,a4paper,10pt]{article}

\renewcommand\topfraction{.9}
\renewcommand\bottomfraction{.1}
\renewcommand\textfraction{.2}
\setlength\textfloatsep  {.5\baselineskip}

\setlength\parindent    {6mm}
\setlength\parsep {0mm}
\setlength\textwidth  {172mm}
\setlength\oddsidemargin  {-7mm}
\setlength\evensidemargin {-7mm}
\setlength\marginparwidth {15mm}

\setlength\topmargin {-12mm} % Nominal distance from top of page to top of
                             % box containing running head.
\setlength\headheight{12pt}  % Height of box containing running head.
\setlength\headsep   {12pt}  % Space between running head and text.
\setlength\topskip   {12pt}  % '\baselineskip' for first line of page.
                           % Bottom of page:

\setlength\footskip  {0mm}  % Distance from baseline of box containing foot
                             % to baseline of last line of text.

\setlength\textheight{740pt} % Height of text (incl. footnotes andfigures,
                             % excl. running head and foot).
                             % For two-column mode:
\setlength\columnsep {8mm}   %    Space between columns
\setlength\columnseprule{0pt}%   Width of rule between columns.

\markboth{\hfill\textsf{\footnotesize\@articletype\ --- \textbf{SACJ, \SACJvolume, \SACJyear}}}{\textsf{\footnotesize\@articletype\ --- \textbf{SACJ, \SACJvolume, \SACJyear}}\hfill}
\pagestyle{myheadings}
\renewcommand{\thepage}{\textsf{\arabic{page}}}
\let\ps@plain\ps@myheadings

\date{}
\renewcommand{\date}[1]{}

\def\@buildtitlefooter{
  \def\@titlefooter{}
  \ifx\@email\@empty\else
    \g@addto@macro\@titlefooter{\textbf{Email:} \email\par\vspace{.5\baselineskip}}%
  \fi
}
\long\def\@theabstract{\@empty}
\long\def\@thekeywords{}
\def\@SACJmaketitle{\newpage
 \null
 \vskip 2em                 % Vertical space above title.
  \renewcommand{\baselinestretch}{1.1}\normalsize
  {\LARGE\textsf{\textbf{\@title}}\par}     % Title set in \LARGE size.
  \renewcommand{\baselinestretch}{1}\normalsize
  \ifx\@author\@empty\else     %Include author spacing
    \vskip 1.5em                % Vertical space after title.
    {\large
     \lineskip .5em
     \textsf{\@author}
     \par}
  \fi
  \ifx\@addresses\@empty\else %Only include space is addresses are present
    {\medskip\textsf{\@addresses}}           % Addresses set in \large size.
  \fi
  \rule{\textwidth}{0.15pt}\par
  \if\@theabstract\@empty\else
    \vspace{0.6em}
    \textsf{\large\uppercase{Abstract}}\par\vspace{1\baselineskip}
    {\small \@theabstract}\par
    \vspace{\baselineskip}
    \textsf{\uppercase{Keywords:}} \@thekeywords\par
    \rule{\textwidth}{0.15pt}\par
  \fi
  \vspace{2.8em}
  %Do we need a footer on the title page? Let's check.
  \@buildtitlefooter
  \ifx\@titlefooter\@empty\else
    \protected@xdef\@thanks{\protect\footnotetext{\hspace{-1.85em}\@titlefooter}}%
  \fi
}
\let\@maketitle\@SACJmaketitle

\long\def\SACJabstract#1{\long\gdef\@theabstract{#1}}
\long\def\SACJkeywords#1{\long\gdef\@thekeywords{#1}}

\newcommand\SACJmaketitle{\par
  \typeout{Processing paper ``\@title''.}
  \begingroup
    \renewcommand\thefootnote{\@fnsymbol\c@footnote}%
    \if@twocolumn
      \ifnum \col@number=\@ne
        \@maketitle
      \else
        \twocolumn[\@maketitle]%
      \fi
    \else
      \newpage
      \global\@topnum\z@   % Prevents figures from going at top of page.
      \@maketitle
    \fi
    \thispagestyle{plain}\@thanks
  \endgroup
  \addcontentsline{toc}{part}{\textsf{\textmd{\large \ \ \ \@title}\\\textmd{\small \hbox to 3em {\hfill}\@authoronly\ }}\dotfill}
  \setcounter{footnote}{0}%
  \global\let\thanks\relax
  \global\let\@maketitle\relax
  \global\let\@thanks\@empty
  \global\let\@date\@empty
  \global\let\title\relax
  \global\let\@title\@empty
  \global\let\author\relax
  \global\let\@author\@empty
  \global\let\@authoronly\@empty
  \global\let\@addresses\@empty
  \global\let\@email\@empty
  \global\let\@theabstract\@empty
  \global\let\@thekeywords\@empty
  \global\let\date\relax
  \global\let\and\relax
}

\newcommand{\SACJreinit}{
  \normalsize
  \setcounter{section}{0}
  \setcounter{figure}{0}
  \setcounter{table}{0}
  \setcounter{footnote}{0}
  \setcounter{equation}{0}
  \setcounter{@authorfootnote}{1}
  \global\let\@maketitle\@SACJmaketitle
}

\renewcommand\section{\@startsection {section}{1}{\z@}%
                                   {-3.5ex \@plus -1ex \@minus -.2ex}%
                                   {2.3ex \@plus.2ex}%
                                   {\large\sffamily\uppercase}}
\renewcommand\subsection{\@startsection{subsection}{2}{\z@}%
                                     {-3.25ex\@plus -1ex \@minus -.2ex}%
                                     {0.9ex \@plus .2ex}%
                                     {\flushleft\normalfont\sffamily\large}}
\renewcommand\subsubsection{\@startsection{subsubsection}{3}{\z@}%
                                     {-3.25ex\@plus -1ex \@minus -.2ex}%
                                     {0.9ex \@plus .2ex}%
                                     {\normalfont\normalsize\sffamily}}

\newenvironment{acknowledgments}{\section*{Acknowledgments}}{}

\renewenvironment{thebibliography}[1]
     {\section*{\refname}%
     \small
      \@mkboth{\MakeUppercase\refname}{\MakeUppercase\refname}%
      \list{\@biblabel{\@arabic\c@enumiv}}%
           {\settowidth\labelwidth{\@biblabel{#1}}%
            \leftmargin\labelwidth
            \advance\leftmargin\labelsep
            \@openbib@code
            \usecounter{enumiv}%
            \let\p@enumiv\@empty
            \renewcommand\theenumiv{\@arabic\c@enumiv}}%
      \sloppy
      \clubpenalty4000
      \@clubpenalty \clubpenalty
      \widowpenalty4000%
      \sfcode`\.\@m}
     {\def\@noitemerr
       {\@latex@warning{Empty `thebibliography' environment}}%
      \endlist}

\renewcommand{\refname}{REFERENCES}
\long\def\@makecaption#1#2{%
  \vskip\abovecaptionskip
  \sbox\@tempboxa{{\small \textit{#1:} #2}}%
  \ifdim \wd\@tempboxa >\hsize
    {\small \textit{#1:} #2}\par
  \else
    \global \@minipagefalse
    \hb@xt@\hsize{\hfil\box\@tempboxa\hfil}%
  \fi
  \vskip\belowcaptionskip}

\def\@listi{\leftmargin\leftmargini
            \parsep \p@ \@plus2\p@ \@minus\p@
            \topsep \parsep
            \itemsep \z@}
\let\@listI\@listi
\@listi
\def\@listii {\leftmargin 1em
              \labelwidth\leftmarginii
              \advance\labelwidth-\labelsep
              \topsep  \parsep
              \parsep  \p@ \@plus\p@  \@minus\p@
              \itemsep \z@}
\def\@listiii{\leftmargin 1em
              \labelwidth\leftmarginiii
              \advance\labelwidth-\labelsep
              \topsep    \parsep
              \parsep    \p@
              \partopsep \z@
              \itemsep   \z@}

\makeatother
\endinput
%%
%% End of file `sacj.cls'.

